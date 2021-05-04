using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nVideo.DATA;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Components
{
    public class AttributeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public AttributeViewComponent(AppDbContext context)
        {
            _context = context;
        }
        //
        public async Task<IViewComponentResult> InvokeAsync(string category)
        {
            var attributesDict = new Dictionary<string, List<Catalog_Value>>();
            var attributes = await _context.Attributes.Where(x => x.Entity.Category.CategoryName.Equals(category)).Include(x => x.Value).ToListAsync();
            foreach (var item in attributes)
            {
                if (!attributesDict.ContainsKey(item.AttributeName))
                {
                    attributesDict.Add(item.AttributeName, new List<Catalog_Value>() { item.Value });
                }
                else
                {
                    attributesDict[item.AttributeName].Add(item.Value);
                }
            }
            return View(attributesDict);
        }
    }
}
