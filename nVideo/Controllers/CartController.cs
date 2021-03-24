using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA;
using System.Linq;
using nVideo.Models;


namespace nVideo.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDBContext _context;
        public CartController(AppDBContext context)
        {
            _context = context;
        }

        public RedirectToRouteResult AddToCart(int entityId, string returnUrl)
        {
            var entity = _context.Entities.FirstOrDefault(x => x.Id == entityId);

            if (entity != null)
            {
                GetCart().AddItem(entity, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int entityId, string returnUrl)
        {
            var entity = _context.Entities.FirstOrDefault(x => x.Id == entityId);


            if (entity != null)
            {
                GetCart().RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
}