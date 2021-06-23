#nullable enable

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Extentions;
using ViewModels;
using Models;
using Services;
using DAL;
using Microsoft.AspNetCore.Authorization;
using System;

namespace nVideo.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly OrderService _order;
        private readonly ShopCart _cart;
        private readonly UserManager<User> _userManager;
        private readonly Database _db;
        private readonly NotificatorService _notify;

        static readonly string CourierDelivery = "Courier Delivery";
        static readonly string SelfDelivery = "Self Delivery";

        public OrderController(ShopCart cart, OrderService order, 
            UserManager<User> userManager, Database appDbContext, 
            NotificatorService notify){
                _order = order;
                _cart = cart;
                _userManager = userManager;
                _db = appDbContext;
                _notify = notify;
        }

        [HttpGet]
        public IActionResult ProcessOrder(string deliveryType) =>
            deliveryType == SelfDelivery
                ? View(SelfDelivery, new SelfDeliveryViewModel(_db.Cities, HttpContext.Request.Cookies["City"]))
                : View(CourierDelivery, new CourierDeliveryViewModel(
                     _userManager.WithProfile(new ClaimsPrincipal(
                        User.Identities)).Profile));

        [HttpPost]
        public async Task<IActionResult> ProcessSelfDelivery(string cityId) =>
            await ProcessOrderForAsync(
                _userManager.WithProfile(new ClaimsPrincipal(
                        User.Identities)), Guid.Parse(cityId));

        [HttpPost]
        public async Task<IActionResult> ProcessCourierDelivery(UserProfile? customerData) =>
           await ProcessOrderForAsync(
                 _userManager.WithProfile(new ClaimsPrincipal(
                        User.Identities)), default(Guid));

        private async Task<IActionResult> ProcessOrderForAsync(User user, Guid cityId){            
            await _notify.About(OrderState.Open,
                await _order.CreateFor(user, cityId), user);
                    await _cart.FlushAsync(user);

            return View("Complete");
        }
    }
}
