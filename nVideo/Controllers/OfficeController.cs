using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nVideo.DATA;
using nVideo.DATA.ControllerModels;
using nVideo.DATA.Services;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using nVideo.DATA.Extentions;
using nVideo.DATA.Validation;

namespace nVideo.Controllers
{

    // Personal Cabinet func.
    [Authorize]
    public class OfficeController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;
        private readonly EmailSenderService _sender;

        public OfficeController(UserManager<User> manager, AppDbContext context, SignInManager<User> signInManager, 
            EmailSenderService sender)
        {
            this._userManager = manager;
            this._dbContext = context;
            this._signInManager = signInManager;
            this._sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Profile() {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager
                    .GetUserIncludeProfile(new ClaimsPrincipal(User.Identities));

                ViewBag.Messages ??= new List<string>();

                if (!user.EmailConfirmed)
                    ViewBag.Messages.Add("Please confirm your mail!");
                
                
                var model = new ProfileModel
                {
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
        public async Task<IActionResult> EditProfile(UserProfile profileModel)
        {
            if (!ModelState.IsValid) return View("EditProfileModalPartial", profileModel);
            
            var user = _userManager
                .GetUserIncludeProfile(new ClaimsPrincipal(User.Identities));

            var either = Validator.ValidateProfile(profileModel);
                
            if (either.Result != Result.Success)
            {
                ModelState.AddModelError("ValidationError", $"{either.Error}" );
                return View("EditProfileModalPartial" ,profileModel);
            }
            
            user.Profile = profileModel;
            var res = await _userManager.UpdateAsync(user);

            if (res.Succeeded){
                return RedirectToAction("Profile");
            }
            else
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("UpdateErrors", error.Description);
                }
            }
            return View("EditProfileModalPartial", profileModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View("ChangePasswordModalPartial", model);
            
            var user = _userManager
                .GetUserIncludeProfile(new ClaimsPrincipal(User.Identities));

            if (user != null)
            {
                var passwordValidator =
                    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                var passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                IdentityResult result =
                    await passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                if (result.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
                    await _userManager.UpdateAsync(user);

                    ViewBag.Messages = new List<string>();
                    ViewBag.Messages.Add("Password changed successfully");

                    return RedirectToAction("Profile");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found");
            }
            return View("ChangePasswordModalPartial", model);
        }

        public async Task<IActionResult> ResendEmailCofirm()
        {
            var user = _userManager
                .GetUserIncludeProfile(new ClaimsPrincipal(User.Identities));

            if (user.EmailConfirmed)
            {
                return RedirectToAction("Profile");
            }
            
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code = code },
                protocol: HttpContext.Request.Scheme);

            try
            {
                await _sender.SendEmailAsync(user.Email, "Confirm your account",
                    $"Verify your email on click by <a href='{callbackUrl}'>link</a>");
            }
            catch (CommandException cEx)
            {
                ViewBag.Errors ??= new List<string>();
                ViewBag.Errors.Add("Specified Email is not exist");
                return View("OnEmailConfirm");
            }
            catch (Exception suddenEx)
            {
                ViewBag.Errors ??= new List<string>();
                ViewBag.Errors.Add("An error occured while sending email.");
                return View("OnEmailConfirm");
            }

            return View("OnEmailConfirm");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
