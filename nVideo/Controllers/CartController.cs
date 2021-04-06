using nVideo.Models;
using Microsoft.AspNetCore.Mvc;


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
        public ViewResult Cart()
        {
            var items = _shopCart.GetShopItems();
            var total = _shopCart.GeComputeTotalValue();

            var viewModel = new ShopCartView(items, total);
            return View(viewModel);
        }

        [HttpGet]
        public void AddToCart(int id)
        {
            if (User.Identity.IsAuthenticated)
                _shopCart.AddToCart(id);
            else
                _shopCart.AddToCartAnon(id);
        }
        [HttpGet]
        public void RemoveFromCart(int id)
        {
            if (User.Identity.IsAuthenticated)
                _shopCart.RevomeFromCart(id);
            else
                _shopCart.RemoveFromCartAnon(id);
            

        }
    }
}
