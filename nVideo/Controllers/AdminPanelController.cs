using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            if(useremail== null) return View("AdminFail");
            var user = await _userManager.FindByEmailAsync(useremail);
            if (user != null) return View("AdminFail");
            await _userManager.AddToRoleAsync(user, "baned");
            return View("Success");
        }
        [HttpPost]
        public async Task<IActionResult> UnBan(string useremail)
        {
            if(useremail== null) return View("AdminFail");
            var user = await _userManager.FindByEmailAsync(useremail);
            if (user != null) return View("AdminFail");
            await _userManager.AddToRoleAsync(user, "user");
            return View("Success");
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(string useremail)
        {
            if(useremail== null) return View("AdminFail");
            var user = await _userManager.FindByEmailAsync(useremail);
            if (user != null) return View("AdminFail");
            await _userManager.AddToRoleAsync(user, "admin");
            return View("Success");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel){
            if (ModelState.IsValid){
                var user = await _userManager.FindByNameAsync(registerModel.Email);
               
                if (user != null) {
                    ModelState.AddModelError("UniqMailError", "User with such login already exist");
                    return View();
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
                        return View(registerModel);
                    }
                    catch (Exception suddenEx){
                        _logger.LogError($"Err with User - {newUser.Email}. \n {suddenEx.Message}");
                        ModelState.AddModelError("SenderError", "An error occured while sending email.");
                        return View(registerModel);
                    }

                    ViewBag.Message = "To complete the registration, check your email address and follow the link provided in the email";
                    return View("OnEmailConfirm");
                }
            }
            return View();
        }
        
        
    }
}