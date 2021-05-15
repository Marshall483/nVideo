#nullable enable


using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.Logging;
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
        
        
        public OrderController(AppDbContext context,
            UserManager<User> userManager,
            ShopCart cart)
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
            // 1. Create an order 
            // 2. Flush the bucket
            // 3. Show "Thank ypu page"
            
            // 

            var order = await PopulateOrderAsync(customerData);
            var cqItems = new ConcurrentQueue<ShopCartItem>(order.Items);

           // await _dbContext.Orders.AddAsync(order);

            ShopCartItem shopCartItem;

            while(cqItems.TryDequeue(out shopCartItem))
            while (shopCartItem.Quanity-- > 0)
                shopCartItem.Quanity = 0;
                   // _shopCart.RevomeFromCart(shopCartItem.Entity.Id);

            return View("Complete");
        }
        
         /// <summary>
        /// Create an order and set reference for each ShopCartItem to Order.
        /// </summary>
        /// <param name="customerData">Represents customer data</param>
        /// <returns> Catalog_Order </returns>
        private async Task<Catalog_Order> PopulateOrderAsync(UserProfile customerData)
        {
            var order = new Catalog_Order
            {
                State = OpenState,
                CreatedTime = DateTime.Now,
                CustomerData = customerData,
                
                User = User.Identity.IsAuthenticated
                    ? await _userManager.GetUserAsync(new ClaimsPrincipal(User.Identities))
                    : null,
                
                Items = _dbContext
                    .ShopCartItems
                    .Where(x => x.UserName == User.Identity.Name)
                    .Include(x => x.Entity)
                    .ToList(),
            };
            
            order.Items.
                ToList().
                ForEach(i => i.Order = order);

            return order;
        }

    }
}