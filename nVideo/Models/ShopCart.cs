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
        private ShopCart(AppDbContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public static ShopCart GetCart(IServiceProvider service)
        {
            var httpContext = service.GetRequiredService<IHttpContextAccessor>().HttpContext;        
            var context = service.GetService<AppDbContext>();           
            var userName = httpContext.User.Identity.Name;
            var cartInfo = httpContext.Request.Cookies["CartId"];
            if (cartInfo != null)
            {
                if (userName != null)
                {
                    var items = GetCartItemFromCookie(userName, cartInfo, context);
                    AddToCartRange(context, userName, items);

                    context.SaveChanges();
                }
            }
            else if (userName != null)
            {
                cartInfo = userName;
            }

            return new ShopCart(context, httpContext) { ShopCartId = cartInfo };
        }

        private static List<ShopCartItem> GetCartItemFromCookie(string userInfo, string cartInfo, AppDbContext context)
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

        private static void AddToCartRange(AppDbContext context, string userName, IEnumerable<ShopCartItem> items)
        {
            foreach (var item in items)
            {
                AddToCart(context, userName, item.Entity.Id, item.Quanity);
            }
        }

        private static void AddToCart(AppDbContext context, string userName, int id, uint quanity)
        {
            var entity = context.Entities.Find(id);

            var cartItem = context.ShopCartItems.FirstOrDefault(x => x.Entity == entity && x.ShopCartId == userName);

            if (cartItem != null)
            {
                cartItem.Quanity += quanity;
                context.ShopCartItems.Update(cartItem);
            }
            else
            {
                context.ShopCartItems.Add(new ShopCartItem
                {
                    ShopCartId = userName,
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
            var cartInfo = _httpContext.Request.Cookies["CartId"];
            if (cartInfo == null)
                cartInfo += $"{id}";
            else
                cartInfo += $" {id}";
            _httpContext.Response.Cookies.Append("CartId", cartInfo);
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
            var cartInfo = _httpContext.Request.Cookies["CartId"];
            cartInfo = cartInfo.Replace($" {id}", string.Empty);
            _httpContext.Response.Cookies.Append("CartId", cartInfo);
        }

        public long GeComputeTotalValue()
        {
            return _context.ShopCartItems.Sum(x => x.Entity.Price * x.Quanity);
        }

        public IEnumerable<ShopCartItem> GetShopItems()
        {
            if (_httpContext.User.Identity.IsAuthenticated)
                return _context.ShopCartItems.Where(x => x.ShopCartId == ShopCartId).Include(x => x.Entity);
            else
            {
                var cartInfo = _httpContext.Request.Cookies["CartId"];
                return GetCartItemFromCookie("anon", cartInfo, _context);
            }
        }
    }
}
