using System.Collections.Generic;
using nVideo.Models;

namespace nVideo.DATA.ControllerModels
{
    public class AdminPanelModel
    {   
        public Catalog_Entity CatalogEntity;
        public List<string> Attributes;
        public List<string> Values;

        public AdminPanelModel(Catalog_Entity catalogEntity)
        {
            CatalogEntity = catalogEntity;
        }
    }
}