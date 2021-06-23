using System.Collections.Generic;

namespace Models
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
