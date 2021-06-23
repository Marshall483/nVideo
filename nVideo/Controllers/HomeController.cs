using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Interfaces;
using Models;
using ViewModels;

#nullable enable

namespace nVideo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCatalog _catalog;

        private IEnumerable<Catalog_Entity> GetThridRandom => 
            _catalog.GetRandomItem();

        public HomeController(IAllCatalog catalog) =>
            _catalog = catalog;

        public IActionResult Index(){
            var model = new HomeViewModel();

            model.ForCarousel = _catalog.GetCarouselItems();
            model.ForFeaturedBlock = _catalog.GetFeaturedItems();
            model.ForNewProductsBlock = _catalog.GetNewItems();
            model.ForThumbnailBlock = GetThridRandom;

            return View(model);
        }      

        public IActionResult Privacy(){
            return View();
        }

        public IActionResult City(string city)
        {
            HttpContext.Response.Cookies.Append("City", city);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
