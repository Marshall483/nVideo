using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Models;

namespace ViewModels
{
    public class AdminPanelModel
    {   
        public Catalog_Entity CatalogEntity;
        public List<string> Attributes;
        public List<string> Values;
        public List<IFormFile> imgs;

        public AdminPanelModel(Catalog_Entity catalogEntity)
        {
            CatalogEntity = catalogEntity;
        }
    }
}