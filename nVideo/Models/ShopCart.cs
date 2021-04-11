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
        private readonly HttpContext _httpContext;
        private string ShopCartId { get; set; }
        public ShopCart(AppDbContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public static ShopCart GetCart(IServiceProvider service)
        {
            var httpContext = service.GetRequiredService<IHttpContextAccessor>().HttpContext;
            var session = httpContext.Session;            
            var context = service.GetService<AppDbContext>();           
            var userName = httpContext.User.Identity.Name;
            var cartInfo = session.GetString("CartId");
            if (cartInfo != null)
            {
                if (userName != null)
                {
                    List<ShopCartItem> items = GetCartItemFromSession(userName, cartInfo, context);
                    cartInfo = userName;
                    AddToCartRange(context, cartInfo, items);
                    session.SetString("CartId", cartInfo);

                    context.SaveChanges();
                }
            }
            else if (userName != null)
            {
                cartInfo = userName;
                session.SetString("CartId", cartInfo);
            }

            return new ShopCart(context, httpContext) { ShopCartId = cartInfo };
        }

        private static List<ShopCartItem> GetCartItemFromSession(string userInfo, string cartInfo, AppDbContext context)
        {
            var list = new List<ShopCartItem>();
            var dict = cartInfo.Split().GroupBy(x => x)
                .Where(x => x.Any())
                .ToDictionary(x=> x.Key, x=> x.Count());
            foreach (var item in dict)
            {
                list.Add(new ShopCartItem
                {
                    ShopCartId = userInfo,
                    Entity = context.Entities.Find(int.Parse(item.Key)),
                    Quanity = (uint)item.Value
                });
            }
            return list;
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
            if (_httpContext.User.Identity.IsAuthenticated)
                AddToCartAuth(id);
            else
                AddToCartAnon(id);
            _context.SaveChanges();
        }

        private void AddToCartAuth(int id)
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
                var shopCartItem = new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    Entity = entity,
                    Quanity = 1
                };
                _context.ShopCartItems.Add(shopCartItem);
            }
        }

        private void AddToCartAnon(int id)
        {
            var session = _httpContext.Session;
            var cartInfo = session.GetString("CartId");
            if (cartInfo == null)
                cartInfo += $"{id}";
            else
                cartInfo += $" {id}";
            session.SetString($"CartId", cartInfo);
        }

        public void RevomeFromCart(int id)
        {
            if (_httpContext.User.Identity.IsAuthenticated)
                RemoveFromCartAuth(id);
            else
                RemoveFromCartAnon(id);
            _context.SaveChanges();
        }

        private void RemoveFromCartAuth(int id)
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
        }

        private void RemoveFromCartAnon(int id)
        {
            var session = _httpContext.Session;
            var cartInfo = session.GetString("CartId");
            cartInfo = cartInfo.Replace($" {id}", string.Empty);
            session.SetString($"CartId", cartInfo);
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
