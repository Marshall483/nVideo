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

        [HttpGet]
        public ViewResult Cart()
        {
            var items = _shopCart.GetShopItems();
            var total = _shopCart.GeComputeTotalValue();

            var viewModel = new ShopCartView(items, total);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {

            _shopCart.AddToCart(id);

            var entity = _context.Entities.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            return RedirectToAction("CategoryFilter", "Catalog", new { category = entity.Category.CategoryName });
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            _shopCart.RevomeFromCart(id);

            var entity = _context.Entities.Find(id);

            return RedirectToAction("CategoryFilter", "Catalog", new { category = entity.Category.CategoryName });
        }
    }
}
