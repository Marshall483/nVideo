using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nVideo.DATA.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using nVideo.DATA;
using nVideo.DATA.ControllerModels;
using nVideo.DATA.ViewModels;
using nVideo.Models;

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
                
                return View(aboutVM);
            }
            throw new ArgumentNullException("Missing parameter: int id");
        }

        [ActionName("AddCommentAsync")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCommentAsync([FromForm] int entityId, [FromForm] string content)
        {
            if (content != null && entityId != null )
            {
                if (content.Length > 1000)
                {
                    ModelState.AddModelError("Error", "Content length must be less that 1000 symbols");
                    return RedirectToAction(actionName: "About", 
                        routeValues: new {id = entityId});
                }
                
                var comment = new Comment()
                {
                    User = await _userManager.GetUserAsync(new ClaimsPrincipal(User.Identities)),
                    Content = content,
                    Entity = _catalog.GetItemById(entityId)
                };

                try
                {
                    await _dbContext.Comments.AddAsync(comment);
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
    }
}
