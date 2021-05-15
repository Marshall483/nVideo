using System.Collections.Generic;
using System.Linq;
using Cart.Infrastructure;
using nVideo.Models;

namespace Cart.DomainUsage
{
    public partial class Cart
    {
        public enum CartStateCode : byte
        {
            [State(typeof(EmptyCartState))] Empty,
            [State(typeof(ActiveCartState))] Active,
            [State(typeof(PaidCartState))] Paid,
        }

        public interface IAddableCartState
        {
            ActiveCartState Add(Catalog_Entity product);
            IEnumerable<Catalog_Entity> Products { get; }
        }

        public interface IOhMyGodable
        {
            public void SayOhMyGodable_Danila();
        }

        public interface INotEmptyCartState
        {
            IEnumerable<Catalog_Entity> Products { get; }
            uint Total { get; }
        }
        
        public abstract class AddableCartState:
            State<Cart>, IAddableCartState {
            
            public IEnumerable<Catalog_Entity> Products => Entity.Products;

            protected AddableCartState(Cart cart) : base(cart) { }

            public ActiveCartState Add(Catalog_Entity product)
            {
                Entity.Products.Add(product);
                Entity.StateCode = CartStateCode.Active;
                return (ActiveCartState) Entity.State;
            }
        }

        public class EmptyCartState : AddableCartState
        {
            public EmptyCartState(Cart entity) : base(entity) { }
        }

        public class ActiveCartState : AddableCartState, INotEmptyCartState
        {
            uint INotEmptyCartState.Total => (uint)Entity.Products.Sum(p => p.Price);
            public ActiveCartState(Cart entity) : base(entity) { }

            public PaidCartState Pay(uint total)
            {
                Entity.Total = total;
                Entity.StateCode = CartStateCode.Paid;
                return (PaidCartState) Entity.State;
            }

            public State<Cart> Remove(Catalog_Entity product)
            {
                Entity.Products.Remove(product);

                if (!Entity.Products.Any())
                    Entity.StateCode = CartStateCode.Empty;

                return Entity.State;
            }

            public EmptyCartState Clear()
            {
                Entity.Products.Clear();
                Entity.StateCode = CartStateCode.Empty;
                return (EmptyCartState) Entity.State;
            }
        }

        public class PaidCartState : State<Cart>, INotEmptyCartState
        {

            public IEnumerable<Catalog_Entity> Products => Entity.Products;
            public uint Total => Entity.Total;

            public PaidCartState(Cart entity) : base(entity) { }
        }
    }
}