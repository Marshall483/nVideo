#nullable enable

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA;
using nVideo.DATA.Extentions;
using nVideo.DATA.ViewModels;
using nVideo.Models;
using nVideo.DATA.Services;
using Microsoft.AspNetCore.Authorization;
using System;

namespace nVideo.Controllers
{
    public static class Extensions
    {
        public static async Task PipeToSync<TIn, TOut>
            (this TIn input, Func<TIn, Task<TOut>> func) =>
               await func(input);

        public static async Task<IActionResult> PipeToResult<TIn, IActionResult>
            (this TIn input, IActionResult result) =>
                await Task.Run( () => result );
    }

    [Authorize]
    public class OrderController : Controller
    {
        private readonly OrderService _order;
        private readonly ShopCart _cart;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _db;
        private readonly NotificatorService _notify;

        static readonly string CourierDelivery = "Courier Delivery";
        static readonly string SelfDelivery = "Self Delivery";

        public OrderController(ShopCart cart, OrderService order, UserManager<User> userManager, AppDbContext appDbContext, NotificatorService notify)
        {
            _order = order;
            _cart = cart;
            _userManager = userManager;
            _db = appDbContext;
            _notify = notify;
        }

        [HttpGet]
        public async Task<IActionResult> ProcessOrder(string deliveryType) =>
            deliveryType == SelfDelivery
                ? View(SelfDelivery, new SelfDeliveryViewModel(_db.Cities))
                : View(CourierDelivery, new CourierDeliveryViewModel(
                    _userManager.GetUserIncludeProfile(new ClaimsPrincipal(
                        User.Identities)).Profile));

        [HttpPost]
        public async Task<IActionResult> ProcessSelfDelivery(string cityId) =>
            await ProcessOrderForAsync(
                await _userManager.FindByNameAsync(
                    User.Identity.Name));

        [HttpPost]
        public async Task<IActionResult> ProcessCourierDelivery(UserProfile customerData) =>
           await ProcessOrderForAsync(
                 await _userManager.FindByNameAsync(
                     User.Identity.Name));

        private async Task<IActionResult> ProcessOrderForAsync(User user){
            await _notify.About(OrderState.Open,
                await _order.CreateFor(user), user);

            return View("Complete");
        }
    }
}