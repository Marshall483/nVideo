using nVideo.DATA.Interfaces;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nVideo.DATA.Services
{
    public class NotificatorService 
    {
        private readonly Dictionary<OrderState, Func<string, Catalog_Order, Task>> _notifyAbout;
        private readonly INotificator _notify;
        public NotificatorService(INotificator notify)
        {
            _notify = notify;
            _notifyAbout = new Dictionary<OrderState, Func<string, Catalog_Order, Task>>{
                { OrderState.Closed, _notify.AboutOrderColsed },
                { OrderState.InProgress, _notify.AboutOrderInProgress },
                { OrderState.ReadyToPick, _notify.AboutReadyToPick },
                { OrderState.Open, _notify.AboutOrderOpened }
            };
        }

        public async Task About(OrderState newState, Catalog_Order order, User user) =>
            await _notifyAbout[newState].Invoke(user.Email, order);
    }
}
