using System.Threading.Tasks;
using nVideo.Models;

namespace nVideo.DATA.Interfaces
{
    public interface INotificator
    {
        public Task AboutOrderOpened(string email, Catalog_Order order);

        public Task AboutReadyToPick(string email, Catalog_Order order);

        public Task AboutOrderInProgress(string email, Catalog_Order order);

        public Task AboutOrderColsed(string email, Catalog_Order order);

    }
}
