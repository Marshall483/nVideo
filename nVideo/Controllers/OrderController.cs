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

        public OrderController(ShopCart cart, OrderService order, 
            UserManager<User> userManager, AppDbContext appDbContext, 
            NotificatorService notify){
                _order = order;
                _cart = cart;
                _userManager = userManager;
                _db = appDbContext;
                _notify = notify;
        }

        [HttpGet]
        public async Task<IActionResult> ProcessOrder(string deliveryType) =>
            deliveryType == SelfDelivery
                ? View(SelfDelivery, new SelfDeliveryViewModel(_db.Cities, HttpContext.Request.Cookies["City"]))
                : View(CourierDelivery, new CourierDeliveryViewModel(
                    _userManager.GetUserIncludeProfile(new ClaimsPrincipal(
                        User.Identities)).Profile));

        [HttpPost]
        public async Task<IActionResult> ProcessSelfDelivery(string cityId) =>
            await ProcessOrderForAsync(
                await _userManager.FindByNameAsync(
                    User.Identity.Name), null);

        [HttpPost]
        public async Task<IActionResult> ProcessCourierDelivery(UserProfile? customerData) =>
           await ProcessOrderForAsync(
                 await _userManager.FindByNameAsync(
                     User.Identity.Name), customerData);

        private async Task<IActionResult> ProcessOrderForAsync(User user, UserProfile? profile){            
            await _notify.About(OrderState.Open,
                await _order.CreateFor(user), user);
                    await _cart.FlushAsync(user);

            return View("Complete");
        }
    }
}
