using ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;

#nullable enable

namespace nVideo.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopCart _shopCart;
        private readonly SelectList _deliverySelect = new SelectList(new string[] { "Self Delivery","Courier Delivery" });
        public CartController(ShopCart shopCart)
        {
            _shopCart = shopCart;
        }


        [HttpGet]
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();

            long total = items != null
                ? items.Sum(x => x.Entity.Price * x.Quanity)
                : 0;

            var viewModel = new ShopCartView(items, total, _deliverySelect );
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

        public IActionResult Checkout() =>
            View(new ShopCartView(_shopCart.GetShopItems(),
                _shopCart.GetShopItems().Sum(i => i.Entity.Price),
                _deliverySelect));

    }
}
