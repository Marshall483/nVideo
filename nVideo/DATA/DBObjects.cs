using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nVideo.Models;

namespace nVideo.DATA
{
    public class DBObjects
    {

        private static Dictionary<string, Catalog_Category> _category;
        private static Dictionary<string, Catalog_Entity> _entity;
        private static List<Image> _images;
        public static void Initial(AppDBContext content)
        {
            //if (!content.Cities.Any())
            //    content.Cities.AddRange(Cities);

            if (!content.Category.Any()) // Если данных нет => получить данные
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Wear.Any())
                content.Wear.AddRange(weras.Select(c => c.Value));

            if (!content.Images.Any())
                content.Images.AddRange(_images);

            content.SaveChanges();
        }

       

    }
}
