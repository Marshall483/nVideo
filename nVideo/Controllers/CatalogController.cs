using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nVideo.DATA.Interfaces;
using System;
using nVideo.DATA.ViewModels;

namespace nVideo.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IAllCatalog _catalog;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IAllCatalog catalog, ILogger<CatalogController> logger){
            _catalog = catalog;
            _logger = logger;
        }

        public ViewResult List(){
            var model = new CatalogViewModel();
            model.Entities = _catalog.GetAllEntnty;

            return View(model);
        }

        [Route("Catalog/CategoryFilter/{category}")]
        public IActionResult CategoryFilter(string category){
            if (!string.IsNullOrEmpty(category)){
                var model = new CatalogViewModel();

                model.Entities = _catalog.GetCategoryMembers(category);

                return View("List", model);
            }
            throw new ArgumentNullException("Missing parameter: string category");
        }

        [Route("Catalog/About/{id}")]
        public ViewResult About(int? id){
            if (id.HasValue){
                return View(_catalog.GetItemById(id));
            }
            throw new ArgumentNullException("Missing parameter: int id");
        }
    }
}
