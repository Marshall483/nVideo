using System.Collections;
using System.Collections.Generic;
using nVideo.Models;

namespace nVideo.DATA.ControllerModels
{
    public class AboutViewModel
    {
        public Catalog_Entity Entity { get; set; }
        public IEnumerable<Catalog_Entity> Related_Products { get; set; }

    }
}