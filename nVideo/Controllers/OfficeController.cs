using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nVideo.DATA;
using nVideo.DATA.ControllerModels;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace nVideo.Controllers
{

    // Personal Cabinet func.
    [Authorize]
    public class OfficeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;
        public OfficeController(UserManager<User> manager, AppDbContext context)
        {
            _userManager = manager;
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Profile() {
            if (User.Identity.IsAuthenticated)
            {
                var principal = new ClaimsPrincipal(User.Identities);
                var id = _userManager.GetUserId(principal);

                var user = _dbContext.Users.
                    Where(u => u.Id.Equals(id)).
                    Include(u => u.Profile).
                    First();

                ViewBag.Messages = new List<string>();

                if (!user.EmailConfirmed)
                    ViewBag.Messages.Add("Please confirm your mail!");

                var model = new ProfileModel{
                    User = user
                };

                var tuple = new Tuple<User, UserProfile>(user, new UserProfile());
                return View(tuple);
            };
            ViewBag.Message = "Not Authenticated";
            return View("Error", new ErrorViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(string id, UserProfile profileModel)
        {
            if (ModelState.IsValid)
            {
                //TODO
            }
            return Ok("Ok");
        }
    }
}
