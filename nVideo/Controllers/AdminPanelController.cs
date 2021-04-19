using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nVideo.DATA.ControllerModels;
using nVideo.DATA.Services;
using nVideo.Models;

namespace nVideo.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminPanelController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly EmailSenderService _sender;
        private readonly ILogger<AccountController> _logger;

        public AdminPanelController(UserManager<User> userManager, EmailSenderService sender, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _sender = sender;
            _logger = logger;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var principal = new ClaimsPrincipal(User.Identities);
            var _admin = await _userManager.GetUserAsync(principal);
            ViewBag.Admin = _admin;
            return View();
        }

        public IActionResult Banhammer()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ban(string useremail)
        {
            if(useremail== null) return Result(2);
            var user = await _userManager.FindByEmailAsync(useremail);
            if (user == null) return Result(1);
            await _userManager.AddToRoleAsync(user, "baned");
            //Indian codding mod: ON
            return Result(0);
        }
        [HttpPost]
        public async Task<IActionResult> UnBan(string useremail)
        {
            if(useremail== null) return Result(2);
            var user = await _userManager.FindByEmailAsync(useremail);
            if (user == null) return Result(1);
            await _userManager.AddToRoleAsync(user, "user");
            return Result(0);
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(string useremail)
        {
            if(useremail== null) return Result(2);
            var user = await _userManager.FindByEmailAsync(useremail);
            if (user == null) return Result(1);
            await _userManager.AddToRoleAsync(user, "admin");
            return Result(0);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel){
            if (ModelState.IsValid){
                var user = await _userManager.FindByNameAsync(registerModel.Email);
               
                if (user != null) {
                    ModelState.AddModelError("UniqMailError", "User with such login already exist");
                    return Result(10);
                }

                var newUser = new User{
                    Email = registerModel.Email,
                    UserName = registerModel.Email,
                    Profile = new UserProfile()
                };


                 var res = await _userManager.CreateAsync(newUser, registerModel.Password);

                if (res.Succeeded)
                {
                    // token generation
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = newUser.Id, code = code },
                        protocol: HttpContext.Request.Scheme);

                    try{
                        await _sender.SendEmailAsync(registerModel.Email, "Confirm your account",
                            $"Verify your email on click by <a href='{callbackUrl}'>link</a>");
                    }
                    catch (CommandException cEx){
                        _logger.LogError($"Err with User - {newUser.Email}. \n {cEx.Message}");
                        ModelState.AddModelError("SenderError", "Specified Email is not exist");
                        return Result(10);
                    }
                    catch (Exception suddenEx){
                        _logger.LogError($"Err with User - {newUser.Email}. \n {suddenEx.Message}");
                        ModelState.AddModelError("SenderError", "An error occured while sending email.");
                        return Result(10);
                    }

                    ViewBag.Message = "To complete the registration, check your email address and follow the link provided in the email";
                    return View("OnEmailConfirm");
                }
            }
            return Result(0);
        }

        [HttpPost]
        public IActionResult AddEntity(AdminPanelModel adminPanelModel)
        {
            bool isFail = false;
            Catalog_Entity catalogEntity = adminPanelModel.CatalogEntity;
            
            List<string> list = adminPanelModel.CategoryAndValue.Split(';').ToList();
            foreach (string s in list)
            {
                List<string> values = s.Split('|').ToList();
                string Attribute = values[0];
                string Value = values[1];
                //add attribute in db
                //add value in db
            }
             //add catalog entity in db
             return Result(0);
        }

        public IActionResult Result(int exepNum)
        {
            switch (exepNum)
            {
                case 0:
                    ViewBag.Message = "The action ended successfully!";
                    break;
                case 1:
                    ViewBag.Message = "ERROR:Cant find the user!";
                    break;
                case 2: 
                    ViewBag.Message = "ERROR:Check forms!";
                    break;
                case 3: 
                    ViewBag.Message = "ERROR: Write normal attribute!";
                    break;
                default:
                    ViewBag.Message = "ERROR:Something wrong happen!";
                    break;
                
            }

            return View();
        }

        public bool AddAttributeAndValueInDB(string a, string value,DbContext _context )
        {

            return true;
        }
        
        
        
    }
}