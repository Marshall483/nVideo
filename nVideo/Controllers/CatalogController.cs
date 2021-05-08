﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nVideo.DATA.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using nVideo.DATA;
using nVideo.DATA.ControllerModels;
using nVideo.DATA.ViewModels;
using nVideo.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace nVideo.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IAllCatalog _catalog;
        private readonly ILogger<CatalogController> _logger;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public CatalogController(IAllCatalog catalog, ILogger<CatalogController> logger,
            AppDbContext context, UserManager<User> userManager){
            _catalog = catalog;
            _logger = logger;
            _dbContext = context;
            _userManager = userManager;
        }

        public ViewResult List(){
            var model = new CatalogViewModel
            {
                Entities = _catalog.GetAllEntity()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult EntityByFilter(Dictionary<string, string> attributes)
        {

            var attr = _dbContext.Attributes.Include(x => x.Value).ToList();

            var attrResult = new List<Catalog_Attribute>();
            var count = 0;
            foreach (var pair in attributes)
            {
                if (pair.Value != null)
                {
                    count++;
                    var temp = attr
                        .Where(a => a.AttributeName.Equals(pair.Key))
                        .Where(a =>
                        {
                            var flag = false;
                            if (a.Value.IntegerValue.HasValue)
                            {
                                if (int.TryParse(pair.Value, out int result))
                                    if (a.Value.IntegerValue.Value == result)
                                        flag = true;
                            }
                            if (!string.IsNullOrEmpty(a.Value.StringValue))
                            {
                                if (a.Value.StringValue.Equals(pair.Value))
                                    flag = true;
                            }
                            return flag;
                        })
                        .ToList();
                    attrResult.AddRange(temp);
                }
            }
            var dict = new Dictionary<int, int>();
            foreach (var item in attrResult)
            {
                if (!dict.ContainsKey(item.EntityId.Value))
                    dict.Add(item.EntityId.Value, 1);
                else
                    dict[item.EntityId.Value] += 1;
            }
            var dictresult = dict.Where(x => x.Value == count);
            var result = new List<Catalog_Entity>();
            foreach (var pair in dictresult)
            {
                result.AddRange(_dbContext.Entities.Where(x => x.Id == pair.Key).Include(i => i.Images)
                .Include(a => a.Attributes)
                .ThenInclude(v => v.Value).ToList());
            }
            var model = new CatalogViewModel
            {
                Entities = result
            };

            return View("List", model);
        }


        [Route("Catalog/CategoryFilter/{category}")]
        public IActionResult CategoryFilter(string category){
            if (!string.IsNullOrEmpty(category)){

                var model = new CatalogViewModel
                {
                    Entities = _catalog.GetCategoryMembers(category),
                };

                return View("List", model);
            }
            throw new ArgumentNullException("Missing parameter: string category");
        }

        [Route("Catalog/About/{id}")]
        public ViewResult About(int? id){
            if (id.HasValue)
            {
                var entity = _catalog.GetItemById(id);

                var aboutVM = new AboutViewModel();
                
                aboutVM.Entity = entity;
                aboutVM.Related_Products = _catalog.GetCategoryMembers(entity.Category.CategoryName);
                aboutVM.SelectRating = new SelectList(new [] {1,2,3,4,5});
                
                return View(aboutVM);
            }
            throw new ArgumentNullException("Missing parameter: int id");
        }

        [ActionName("AddCommentAsync")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCommentAsync(
            [FromForm] int entityId,
            [FromForm] string rating,
            [FromForm] string content)
        {
            if (content != null && entityId != null )
            {
                if (content.Length > 1000)
                {
                    ModelState.AddModelError("Error", "Content length must be less that 1000 symbols");
                    return RedirectToAction(actionName: "About", 
                        routeValues: new {id = entityId});
                }

                var entity = _catalog.GetItemById(entityId);
                entity.Raiting = UpdateRating(entity, Convert.ToByte(rating));
                
                
                var comment = new Comment()
                {
                    User = await _userManager.GetUserAsync(new ClaimsPrincipal(User.Identities)),
                    Content = content,
                    Entity = entity,
                    Raiting = Convert.ToUInt16(rating)
                };

                try
                {
                    await _dbContext.Comments.AddAsync(comment);
                    _dbContext.Entities.Update(entity);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError("Error", "Ooops, something went wrong, try again later");
                }
                
                return RedirectToAction(actionName: "About", 
                    routeValues: new {id = entityId});
            }
            
            ModelState.AddModelError("Error", "Incorrect Comment");
            return RedirectToAction(actionName: "About", 
                routeValues: new {id = entityId}); 
        }

        private byte UpdateRating(Catalog_Entity entity, byte rating)
        {
            //Calculate Average.
            var commentsCount = entity.Comments.Count;
            var currentRating = entity.Raiting;

            var beforeSmm = currentRating * commentsCount;
            var newCommentsCount = ++commentsCount;
            var newSum = beforeSmm + rating;

            return Convert.ToByte(newSum / newCommentsCount);
            
        }
    }
}
