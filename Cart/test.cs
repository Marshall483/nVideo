using Cart.DomainUsage;
using Cart.Infrastructure;
using nVideo.Models;

namespace Cart
{
    
    public class Foo
    {

        public void DoFoo()
        {
            var someState = (State<DomainUsage.Cart>) new Cart.DomainUsage.Cart.ActiveCartState(new DomainUsage.Cart(new User()));

            switch (someState)
            {
                case DomainUsage.Cart.ActiveCartState activeState:
                    var activeCart = activeState;
                    break;
                
                
            }


            
        }
    }

}