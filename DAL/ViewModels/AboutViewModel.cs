using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Models;

namespace ViewModels
{
    public class AboutViewModel
    {
        public Catalog_Entity Entity { get; set; }
        public IEnumerable<Catalog_Entity> Related_Products { get; set; }
        public SelectList SelectRating { get; set; }
    }
}