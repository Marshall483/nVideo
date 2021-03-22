using System.Collections.Generic;
using System.Linq;

namespace nVideo.Models
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(Catalog_Entity entity, int quantity)
        {
            var line = _lineCollection
                .FirstOrDefault(x => x.Entity.Id == entity.Id);

            if (line == null)
            {
                _lineCollection.Add(new CartLine
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
            _lineCollection.RemoveAll(x => x.Entity.Id == entity.Id);
        }
        
        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(x => x.Entity.Price *  x.Quantity);
        }
        
        public void Clear()
        {
            _lineCollection.Clear();
        }
        
        public IEnumerable<CartLine> Lines => _lineCollection;
    }
}