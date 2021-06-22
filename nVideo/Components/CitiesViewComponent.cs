using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nVideo.DATA;
using nVideo.DATA.Services;
using nVideo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nVideo.Components
{
    public class CitiesViewComponent : ViewComponent
    {
        private volatile AppDbContext _context;
        public CitiesViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var city = HttpContext.Request.Cookies["City"];
            
            if (string.IsNullOrEmpty(city))
            {
                city = await LocatorService.GetyCityAsync();
            
                if (_context.Cities.FirstOrDefault(x => x.Name.Equals(city)) == null)
                    city = "Sorry, we cant locate you(";

                HttpContext.Response.Cookies.Append("City", city);
            }


            var model = new CitiesViewModel(city, _context.Cities.ToList());
            
            return View(model);
        }
    }
}
