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
            await this.SendNotify(email, $"Your order from {order.CreatedTime} is now open!");

        public async Task AboutReadyToPick(string email, Catalog_Order order) =>
            await this.SendNotify(email, $"Your order from {order.CreatedTime} ready to pick!");

        public async Task AboutOrderInProgress(string email, Catalog_Order order) =>
            await this.SendNotify(email, $"Your order from {order.CreatedTime} change state to in progress!");

        public async Task AboutOrderColsed(string email, Catalog_Order order) =>
            await this.SendNotify(email, $"Your order from {order.CreatedTime} closed!");

        private async Task SendNotify(string email, string message) =>
            await _sender.SendEmailAsync(email, "Notification", message);

    }
}
