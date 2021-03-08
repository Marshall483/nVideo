﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA.ControllerModels;
using nVideo.Models;
using nVideo.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MailKit;
using nVideo.DATA.Extentions;
using nVideo.DATA.Services;

namespace nVideo.Controllers
{
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
                    ModelState.AddModelError("UniqMailError", "User wich such login already exist");
                    return View();
                }

                var newUser = new User{
                    Email = registerModel.Email,
                    UserName = registerModel.Email
                };

                var res = await _userManager.CreateAsync(newUser, registerModel.Password);

                if (res.Succeeded){
                    // генерация токена для пользователя
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = newUser.Id, code = code },
                        protocol: HttpContext.Request.Scheme);

                    try{
                        await _sender.SendEmailAsync(registerModel.Email, "Confirm your account",
                            $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
                    }
                    catch (CommandException cEx){
                        _logger.LogError($"Err wich User - {newUser.Email}. \n {cEx.Message}");
                        ModelState.AddModelError(string.Empty, "Указанный Email не существует");
                        return View(registerModel);
                    }
                    catch (Exception suddenEx){
                        _logger.LogError($"Err wich User - {newUser.Email}. \n {suddenEx.Message}");
                        ModelState.AddModelError(string.Empty, "При попытке отправки письма произошла ошибка.");
                        return View(registerModel);
                    }

                    ViewBag.Message = "Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме";
                    return View("OnEmailConfirm");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult VerifyEmail(string Email){
            return Json(_userManager.IsNameAlreadyExist(Email));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error", new ErrorViewModel());
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Profile", "Office");
            else
                return View("Error", new ErrorViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model){
            if (ModelState.IsValid){
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null){

                    if (!await _userManager.IsEmailConfirmedAsync(user)){
                        ModelState.AddModelError(string.Empty, "У вас не потверждена почта");
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
                    ModelState.AddModelError(string.Empty, "Неверный логин и/или пароль.");
                }
            }
            return View(model);
        }
    }
}
