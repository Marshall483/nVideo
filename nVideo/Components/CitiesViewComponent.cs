using Microsoft.AspNetCore.Mvc;
using DAL;
using System.Linq;
using FSharp;
using Location;
using System.Threading.Tasks;
using Models;

namespace nVideo.Components
{
    public class CitiesViewComponent : ViewComponent
    {
        private volatile Database _context;
        public CitiesViewComponent(Database context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var city = HttpContext.Request.Cookies["City"];
            
            if (string.IsNullOrEmpty(city))
            {
                city = await Locator.LocatorService.GetCityAsync();
            
                if (_context.Cities.FirstOrDefault(x => x.Name.Equals(city)) == null)
                    city = "Sorry, we cant locate you(";

                HttpContext.Response.Cookies.Append("City", city);
            }


            var model = new CitiesViewModel(city, _context.Cities.ToList());
            
            return View(model);
        }
    }
}
