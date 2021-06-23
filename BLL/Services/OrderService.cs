using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;
using DAL;

namespace Services
{

    public class OrderService
    {
        private readonly Database _db;

        private readonly Dictionary<OrderState, string> _states = new Dictionary<OrderState, string>{
                { OrderState.Closed, "Closed" },
                { OrderState.InProgress, "In Progress" },
                { OrderState.Open, "Open" },
                { OrderState.ReadyToPick, "Ready To Pick" }
        };
      
        public OrderService(Database context) =>
            _db = context;

        public async Task<Catalog_Order> CreateFor(User user, Guid cidyId) =>
            await SaveOrder(
                RegisterOrder(ChangeStateTo(
                    OrderState.Open, CreateOrderFor(
                        user, cidyId))));

        public Catalog_Order ChangeStateTo(OrderState newState, Catalog_Order order) =>
            EnsureUpdated(SetState(newState, order));

        public Catalog_Order EnsureUpdated(Catalog_Order order) =>
            _db.Orders.Any(o => o.Id == order.Id)
                ? _db.Orders.Update(order).Entity
                : order;

        private IEnumerable<Ordered_Item> GetOrderedItems(User user) =>
           _db.ShopCartItems
           .Where(x => x.UserName == user.Email)
               .Include(x => x.Entity)
                   .Select(x => new Ordered_Item(x.Entity, x.Quanity))
                       .ToList();

        public async Task<Catalog_Order> SaveOrder(Catalog_Order order)
        {
            await _db.SaveChangesAsync();
            return order;
        }

        public Catalog_Order SetState(OrderState newState, Catalog_Order order)
        {
            order.State = _states[newState];
            return order;
        }
        
        private Catalog_Order RegisterOrder(Catalog_Order order)
        {
            _db.OrderedItem.AddRange(order.OrderedItems);
            _db.Orders.Add(order);
            return order;
        }

        private Catalog_Order SetReferencesToItems(Catalog_Order order)
        {
            foreach (var item in order.OrderedItems)
                item.Order = order;

            return order;
        }

        private Catalog_Order CreateOrderFor(User user, Guid cityId) =>
            SetReferencesToItems(
                new Catalog_Order {
                    User = user,                
                    State = _states[OrderState.Open],
                    CreatedTime = DateTime.Now,
                    CustomerData = user.Profile,
                    IsSelfDelivery = cityId != default,
                    CityId =  null,
                    OrderedItems = GetOrderedItems(user) // <-- Items
                });   
    }
}
