using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nVideo.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nVideo.DATA.ViewModels;

namespace nVideo.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IAllCatalog _allCatalog;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IAllCatalog catalog, ILogger<CatalogController> logger)
        {
            _allCatalog = catalog;
            _logger = logger;
        }

        public ViewResult List()
        {
            var model = new CatalogViewModel();
            model.Entities = _allCatalog.AllEntnty;

            return View(model);
        }

        [Route("Catalog/View/{id}")]
        public ViewResult View(int? id)
        {
            if (id.HasValue)
            {
                // success
            }
            return View();
        }
    }
}
