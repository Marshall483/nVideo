using nVideo.Models;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace nVideo.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopCart _shopCart;
        private readonly AppDbContext _context;
        public CartController(ShopCart shopCart, AppDbContext context)
        {
            _shopCart = shopCart;
            _context = context;
        }

<<<<<<< HEAD
        /* [HttpGet]
       public ViewResult Cart()
=======
        [HttpGet]
        public ViewResult Index()
>>>>>>> NoProduction
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
        }*/

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
