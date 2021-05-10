using System.Collections.Generic;
using nVideo.Models;

namespace nVideo.DATA.ViewModels
{
    public class SelfDeliveryViewModel
    {
        public IEnumerable<City> Cities { get; set; }

        public SelfDeliveryViewModel(IEnumerable<City> cities)
        {
            Cities = cities;
        }
    }
}