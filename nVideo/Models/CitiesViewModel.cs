using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class CitiesViewModel
    {
        public string City { get; set; }
        public IEnumerable<City> Cities { get; set; }

        public CitiesViewModel (string city, IEnumerable<City> cities)
        {
            City = city;
            Cities = cities;
        }
    }
}
