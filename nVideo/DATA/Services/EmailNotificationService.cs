using System;
using System.Threading.Tasks;
using nVideo.Models;
using nVideo.DATA.Interfaces;

namespace nVideo.DATA.Services
{
    public class EmailNotificationService : INotificator
    {
        private readonly EmailSenderService _sender;

        public EmailNotificationService(EmailSenderService sender) =>
            _sender = sender;
        
        public async Task AboutOrderOpened(string email, Catalog_Order order) =>
            await this.SendNotify(email, $"Your order from {PrettyTime(order.CreatedTime)} with identifier {order.Id} is now open!");

        public async Task AboutReadyToPick(string email, Catalog_Order order) =>
            await this.SendNotify(email, $"Your order from {PrettyTime(order.CreatedTime)} with identifier {order.Id} ready to pick!");

        public async Task AboutOrderInProgress(string email, Catalog_Order order) =>
            await this.SendNotify(email, $"Your order from {PrettyTime(order.CreatedTime)} with identifier {order.Id} change state to in progress!");

        public async Task AboutOrderColsed(string email, Catalog_Order order) =>
            await this.SendNotify(email, $"Your order from {PrettyTime(order.CreatedTime)} with identifier {order.Id} closed!");

        private async Task SendNotify(string email, string message) =>
            await _sender.SendEmailAsync(email, "Notification", message);

        private string PrettyTime(DateTime time) =>
            time.ToString("MMMM dd, yyyy");

    }
}
