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
                    httpContext.Response.Cookies.Delete("CartId");
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
            if (cartInfo == null)
                return null;
            
            var list = new List<ShopCartItem>();
            
            var dict = cartInfo
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .GroupBy(x => x)
                .Where(x => x.Any())
                .ToDictionary(x=> x.Key, x=> x.Count());
            
            foreach (var item in dict)
            {
                list.Add(new ShopCartItem
                {
                    UserName = userInfo,
                    
                    Entity = context
                        .Entities
                        .Include(x => x.Images)
                        .FirstOrDefault(x => x.Id == item.Key),
                    
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

            var cartItem = context.ShopCartItems.FirstOrDefault(x => x.Entity == entity);

            if (cartItem != null)
            {
                cartItem.Quanity += quanity;
                context.ShopCartItems.Update(cartItem);
            }
            else
            {
                context.ShopCartItems.Add(new ShopCartItem
                {
                    UserName = userName,
                    Entity = entity,
                    Quanity = quanity
                });
            }
        }

        public void AddToCart(int id)
        {
            if (_httpContext.User.Identity.IsAuthenticated)
            {
                AddToCartAuth(id);
                _context.SaveChanges();
            }

            else
                AddToCartAnon(id);

        }

        private void AddToCartAuth(int id)
        {
            var entity = _context.Entities.Find(id);

            var item = _context.ShopCartItems.FirstOrDefault(x => x.Entity == entity && x.UserName == _httpContext.User.Identity.Name);
            if (item != null)
            {
                item.Quanity += 1;
                _context.ShopCartItems.Update(item);
            }
            else
            {
                var shopCartItem = new ShopCartItem
                {
                    UserName = ShopCartId,
                    Entity = entity,
                    Quanity = 1
                };
                _context.ShopCartItems.Add(shopCartItem);
            }
        }

        private void AddToCartAnon(int id)
        {
            var cartInfo = _httpContext.Request.Cookies["CartId"]?.Split().ToList();
            if (cartInfo == null)
                cartInfo = new List<string>();
            cartInfo.Add(id.ToString());
            var output = string.Empty;
            foreach (var item in cartInfo)
            {
                output += item + " ";
            }
            _httpContext.Response.Cookies.Append("CartId", output);
        }

        public void RevomeFromCart(int id)
        {
            if (_httpContext.User.Identity.IsAuthenticated)
            {
                RemoveFromCartAuth(id);
                _context.SaveChanges();
            }

            else
                RemoveFromCartAnon(id);

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
            var cartInfo = _httpContext.Request.Cookies["CartId"].Split().ToList();
            if (cartInfo.Count() == 1)
                _httpContext.Response.Cookies.Delete("CartId");
            else
            {
                cartInfo.Remove(id.ToString());
                var output = string.Empty;
                foreach (var item in cartInfo)
                {
                    output += item + " ";
                }
                _httpContext.Response.Cookies.Append("CartId", output);
            }
        }

        public IEnumerable<ShopCartItem> GetShopItems()
        {
            if (_httpContext.User.Identity.IsAuthenticated)
                return _context
                    .ShopCartItems
                    .Where(x => x.UserName == _httpContext.User.Identity.Name)
                    .Include(x => x.Entity)
                    .Include(x => x.Entity.Images);
            else
            {
                var cartInfo = _httpContext.Request.Cookies["CartId"];
                return GetCartItemFromCookie("anon", cartInfo, _context);
            }
        }
    }
}
