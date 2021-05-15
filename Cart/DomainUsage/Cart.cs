using System;
using System.Collections.Generic;
using Cart.Infrastructure;
using nVideo.Models;

namespace Cart.DomainUsage
{
    public interface IHasState<TStateCode, TEntity>
        where TEntity : class {
        
        TStateCode StateCode { get; }
        State<TEntity> State { get; }
    }
    
    public partial class Cart : IHasState<Cart.CartStateCode, Cart>
    {
        public User User { get; protected set; }
        public CartStateCode StateCode { get; protected set; }
        public State<Cart> State => StateCode.ToState<Cart>(this);
        public uint Total { get; protected set; }
        protected virtual ICollection<Catalog_Entity> Products { get; set; }
            = new List<Catalog_Entity>();
        
        // For ORM.
        protected Cart() { }

        public Cart(User user)
        {
            User = user
                   ?? throw new ArgumentException(nameof(user));
            
            StateCode = CartStateCode.Active;
        }
        public Cart(User user, IEnumerable<Catalog_Entity> products) 
            : this(user)
        {
            StateCode = CartStateCode.Empty;
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public Cart(User user, IEnumerable<Catalog_Entity> products, uint total)
          : this(user, products)
        {
            // uint cant be negative.
            Total = total;
        }
    }    
}