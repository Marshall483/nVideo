using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using nVideo.DATA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nVideo.Models
{
    public class ShopCart
    {
        private readonly AppDbContext _context;
        private string ShopCartId { get; set; }
        public ShopCart(AppDbContext context)
        {
            _context = context;
        }
        public static ShopCart GetCart(IServiceProvider service)
        {
            var httpContext = service.GetRequiredService<IHttpContextAccessor>().HttpContext;
            var session = httpContext.Session;            
            var context = service.GetService<AppDbContext>();           
            var userName = httpContext.User.Identity.Name;
            var shopCartId = session.GetString("CartId");
            if (shopCartId != null)
            {
                if (userName != null)
                {
                    if (shopCartId != userName)
                    {
                        var items = context.ShopCartItems.Where(x => x.ShopCartId == shopCartId).Include(x => x.Entity).ToList();
                        shopCartId = userName;
                        AddToCartRange(context, shopCartId, items);
                        context.ShopCartItems.RemoveRange(items);

                        context.SaveChanges();
                    }
                }
                else if (!Guid.TryParse(shopCartId, out Guid guid))
                {
                    shopCartId = Guid.NewGuid().ToString();
                }

            }
            else
            {
                if (userName != null)
                    shopCartId = userName;
                else
                    shopCartId = Guid.NewGuid().ToString();
            }
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        private static void AddToCartRange(AppDbContext context, string shopCartId, IEnumerable<ShopCartItem> items)
        {
            foreach (var item in items)
            {
                AddToCart(context, shopCartId, item.Entity.Id, item.Quanity);
            }
        }

        private static void AddToCart(AppDbContext context, string shopCartId, int id, uint quanity)
        {
            var entity = context.Entities.Find(id);

            var cartItem = context.ShopCartItems.FirstOrDefault(x => x.Entity == entity && x.ShopCartId == shopCartId);

            if (cartItem != null)
            {
                cartItem.Quanity += quanity;
                context.ShopCartItems.Update(cartItem);
            }
            else
            {
                context.ShopCartItems.Add(new ShopCartItem
                {
                    ShopCartId = shopCartId,
                    Entity = entity,
                    Quanity = quanity
                });
            }
        }

        public void AddToCart(int id)
        {
            var entity = _context.Entities.Find(id);

            var item = _context.ShopCartItems.FirstOrDefault(x => x.Entity == entity && x.ShopCartId == ShopCartId);

            if (item != null)
            {
                item.Quanity += 1;
                _context.ShopCartItems.Update(item);
            }
            else
            {
                _context.ShopCartItems.Add(new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    Entity = entity,
                    Quanity = 1
                });
            }

            _context.SaveChanges();
        }

        public void RevomeFromCart(int id)
        {
            var entity = _context.Entities.Find(id);

            var item = _context.ShopCartItems.FirstOrDefault(x => x.Entity.Id == entity.Id);

            if (item.Quanity == 1)
            {
                _context.ShopCartItems.Remove(item);
            }
            else
            {
                item.Quanity -= 1;
                _context.ShopCartItems.Update(item);
            }

            _context.SaveChanges();
        }

        public long GeComputeTotalValue()
        {
            return _context.ShopCartItems.Sum(x => x.Entity.Price * x.Quanity);
        }

        public IEnumerable<ShopCartItem> GetShopItems()
        {
            return _context.ShopCartItems.Where(x => x.ShopCartId == ShopCartId).Include(x => x.Entity);
        }
    }
}
