using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MailKit;
using nVideo.DATA.Extentions;
using nVideo.DATA.Services;
using nVideo.Models;
using nVideo.DATA.ControllerModels;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace nVideo.Controllers
{
    //Registration and authorization func.
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly EmailSenderService _sender;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signManager, EmailSenderService sender, ILogger<AccountController> logger){
            _userManager = userManager;
            _signInManager = signManager;
            _sender = sender;
            _logger = logger;
        }

        //Standard patch to redirect non-auth is ~/Account/Login
        [HttpGet]
        public IActionResult Login(){
            return View("Register");
        }

        [HttpGet]
        public IActionResult Register(){
            return View();
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

        [HttpGet]
        public IActionResult VerifyEmail(string email){
            return Json(_userManager.IsNameAlreadyExist(email));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code){
            ViewBag.Errors = new List<string>();

            if (userId == null || code == null)
            {
                ViewBag.Errors.Add("Incorrect input parameters");
                return View("OnEmailConfirm");
            }
            
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null){
                ViewBag.Message.Add("User not exist, or token expired");
                return View("OnEmailConfirm");
            }
            
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded) // redirect on cabinet
                return RedirectToAction("Profile", "Office");
            else
            {
                ViewBag.Message.Add("I`m don`t know what happening, but result !Succeeded");
                return View("OnEmailConfirm");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model){
            if (ModelState.IsValid){
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null){

                    if (!await _userManager.IsEmailConfirmedAsync(user)){
                        ModelState.AddModelError(string.Empty, "Please confirm your email!");
                    }

                    var res = await _signInManager.PasswordSignInAsync(model.Email,
                        model.Password,
                        model.RememberMe,
                        false);

                    if (res.Succeeded){
                        return RedirectToAction("Profile", "Office");
                    }
                }
                else{
                    ModelState.AddModelError(string.Empty, "Incorrect login or password.");
                }
            }
            return RedirectToAction("Register", "Account");
        }
    }
}
