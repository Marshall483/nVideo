#nullable enable


using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nVideo.DATA;
using nVideo.DATA.Extentions;
using nVideo.DATA.ViewModels;
using nVideo.Models;

namespace nVideo.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager; 
        private readonly ShopCart _shopCart;

        static readonly string CourierDelivery = "Courier Delivery";
        static readonly string SelfDelivery = "Self Delivery";

        static readonly string InProgressState = "InProcess";
        private static readonly string OpenState = "Open";
        private static readonly string ClosedState = "Closed";
        
        
        public OrderController(AppDbContext context, UserManager<User> userManager, ShopCart cart)
        {
            _userManager = userManager;
            _dbContext = context;
            _shopCart = cart;
        }

        [HttpGet]
        public async Task<IActionResult> ProcessOrder(string deliveryType) 
        {
            if (deliveryType == CourierDelivery)
            {
                if (User.Identity.IsAuthenticated) 
                    return View(CourierDelivery,
                        new CourierDeliveryViewModel(_userManager.GetUserIncludeProfile
                            (new ClaimsPrincipal(User.Identities)).Profile));
                
                return View(CourierDelivery, new CourierDeliveryViewModel(null));
            }
            // If Self del., not interesting auth or not.
            return View(SelfDelivery, new SelfDeliveryViewModel(_dbContext.Cities));
        }
        
        [HttpPost]
        public async Task<IActionResult> ProcessSelfDelivery(string cityId)
        {
            var items = _dbContext
                .ShopCartItems
                .Where(x => x.UserName == User.Identity.Name)
                .Include(x => x.Entity)
                .ToList();
            
            foreach (var id in items)
                _shopCart.RevomeFromCart(id.Entity.Id);

            return View("Complete");
        }
        
        [HttpPost]
        public async Task<IActionResult> ProcessCourierDelivery(UserProfile customerData)
        {
            var order = await PopulateOrderAsync(customerData);

            foreach (var item in order.Items)
                item.Order = order;
            
            // While removing from cart, another thread modify orders collection.
            var temp = order.Items.Select(i => i.Entity.Id).ToArray();
            int[] itemsId = new int[temp.Count()];
            Array.Copy(temp, itemsId, temp.Count());
            
            await _dbContext.Orders.AddAsync(order);

            foreach (var id in itemsId)
                _shopCart.RevomeFromCart(id);
            
            return View("Complete");
        }

        private async Task<Catalog_Order> PopulateOrderAsync(UserProfile customerData) =>
            new Catalog_Order()
            {
                User = User.Identity.IsAuthenticated 
                    ? await _userManager.GetUserAsync(new ClaimsPrincipal(User.Identities))
                    : null,

                State = OpenState,
                CreatedTime = DateTime.Now,
                CustomerData = customerData,

                Items = _dbContext
                    .ShopCartItems
                    .Where(x => x.UserName == User.Identity.Name)
                    .Include(x => x.Entity)
                    .ToList(),
            };

    }
}