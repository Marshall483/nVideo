using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA.ControllerModels;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Controllers
{
    [Authorize]
    public class OfficeController : Controller
    {

        private readonly UserManager<User> _userManager;
        public OfficeController(UserManager<User> manager){
            _userManager = manager;
        }

        [HttpGet]
        public IActionResult Profile(){
            if (User.Identity.IsAuthenticated)
            {
                var model = new ProfileModel {
                    User = new User { 
                          Email = User.Identity.Name}
                };
                return View(model);
            }
            ViewBag.Message = "Not Authenticated";
            return View("Error", new ErrorViewModel());
        }
    }
}
