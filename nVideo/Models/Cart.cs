using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Cart
    {
        private readonly List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Catalog_Entity entity, int quantity)
        {
            CartLine line = lineCollection
                .Where(x => x.Entity.Id == entity.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Entity = entity,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Catalog_Entity entity)
        {
            lineCollection.RemoveAll(x => x.Entity.Id == entity.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Entity.Price * x.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Catalog_Entity Entity { get; set; }
        public int Quantity { get; set; }
    }

}
