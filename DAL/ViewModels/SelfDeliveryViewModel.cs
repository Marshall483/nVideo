using System.Collections.Generic;
using Models;

namespace ViewModels
{
    public class SelfDeliveryViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public string CustomerCity { get; set; }
        public SelfDeliveryViewModel(IEnumerable<City> cities, string customerCity)
        {
            Cities = cities;
            CustomerCity = customerCity;
        }
    }
}