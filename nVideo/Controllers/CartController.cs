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
        public void AddtoCart(int id)
        { 
            _shopCart.AddToCart(id);
        }
        [HttpGet]
        public void RemoveFromCart(int id)
        {
            _shopCart.RevomeFromCart(id);

        }
    }
}
