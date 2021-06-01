using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using nVideo.Models;

namespace nVideo.DATA.ControllerModels
{
    public class AboutViewModel
    {
        public Catalog_Entity Entity { get; set; }
        public IEnumerable<Catalog_Entity> Related_Products { get; set; }
        public SelectList SelectRating { get; set; }
    }
}