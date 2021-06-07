using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA;
using nVideo.DATA.ControllerModels;
using nVideo.DATA.Services;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using nVideo.DATA.Extentions;
using nVideo.DATA.ViewModels;

#nullable  enable

namespace nVideo.Controllers
{
    // Personal Cabinet func.
    [Authorize]
    public class OfficeController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _user;
        private readonly AppDbContext _dbContext;
        private readonly EmailSenderService _sender;
        private readonly IPasswordHasher<User> _hasher;

        public OfficeController(UserManager<User> manager, AppDbContext context, 
            SignInManager<User> signInManager, EmailSenderService sender,
            IPasswordHasher<User> hasher)
        {
            _user = manager;
            _dbContext = context;
            _signInManager = signInManager;
            _sender = sender;
            _hasher = hasher;
        }

        [HttpGet]
        public IActionResult Profile() {
            var user = _user
                    .GetUserIncludeProfileAndOreders(new ClaimsPrincipal(User.Identities));

            if (!user.EmailConfirmed)
                ViewBag.Messages.Add("Please confirm your mail!");

            var tuple = new Tuple<User, UserProfile>(user, new UserProfile());

            return View(tuple);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserProfile profileModel)
        {
            if (!ModelState.IsValid) return View("EditProfileModalPartial", profileModel);
            
            var user = _user
                .WithProfile(new ClaimsPrincipal(User.Identities));
            
            user.Profile = profileModel;
            var res = await _user.UpdateAsync(user);

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
            if (!ModelState.IsValid) 
                return View("ChangePasswordModalPartial", model);
            
            var user = _user.WithProfile(new ClaimsPrincipal(User.Identities));
            var passwordsMatch = await _user.CheckPasswordAsync(user, model.OldPassword);

            if (passwordsMatch)
            {
                user.PasswordHash = _hasher.HashPassword(user, model.NewPassword);
                await _user.UpdateAsync(user);
                return RedirectToAction("Profile");
            }

            ModelState.AddModelError(string.Empty, "Incorrect password.");
            return View("ChangePasswordModalPartial", model);
        }

        public async Task<IActionResult> ResendEmailCofirm()
        {
            var user = _user
                .WithProfile(new ClaimsPrincipal(User.Identities));
            
            var code = await _user.GenerateEmailConfirmationTokenAsync(user);
            
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code },
                protocol: HttpContext.Request.Scheme);

            try
            {
                await _sender.SendEmailAsync(user.Email, "Confirm your account",
                    $"Verify your email on click by <a href='{callbackUrl}'>link</a>");
            }
            catch (CommandException cEx)
            {
                ViewBag.Errors ??= new List<string>();
                ViewBag.Errors.Add(cEx.Message);
                return View("OnEmailConfirm");
            }
            catch
            {
                ViewBag.Errors ??= new List<string>();
                ViewBag.Errors.Add("An error occured while sending email.");
                return View("OnEmailConfirm");
            }

            return View("OnEmailConfirm");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAvatar(ChangeAvatarViewModel avatarVM)
        {
            if (avatarVM.Avatar == null || !AssertThatImage(avatarVM.Avatar))
            {
                string error = "Invalid file format. \n " +
                                    "Must be .png, .jpg, .jpeg ";
                return View($"ChangeAvatarPartial", new ChangeAvatarViewModel { Error = error });
            }

            var user = _user.WithProfile(new ClaimsPrincipal(User.Identities));

            byte[] imageData = null; 
            using (var binaryReader = new BinaryReader(avatarVM.Avatar.OpenReadStream()))
            { 
                imageData = binaryReader.ReadBytes((int) avatarVM.Avatar.Length);
            }
            user.Profile.Avatar = imageData;
            
            _dbContext.Users.Update(user); 
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Profile");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool AssertThatImage(IFormFile file)
        {
            var name = file.FileName;
            var extension = name //Extract extension
                .Substring(name.LastIndexOf('.'), name.Length - name.LastIndexOf('.')) 
                .ToLower();

            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                return 1 != 0;

            return false;
        }
    }
}
