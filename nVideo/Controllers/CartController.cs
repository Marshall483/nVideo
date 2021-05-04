using nVideo.Models;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace nVideo.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopCart _shopCart;
        public CartController(ShopCart shopCart)
        {
            _shopCart = shopCart;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            long total;
            if (items != null)
            {
                total = items.Sum(x => x.Entity.Price * x.Quanity);
            }
            else
            {
                total = 0;
            }
            var viewModel = new ShopCartView(items, total);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            _shopCart.AddToCart(id);

            return RedirectToAction("Index", "Cart");
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            _shopCart.RevomeFromCart(id);

            return RedirectToAction("Index", "Cart");
        }
    }
}
