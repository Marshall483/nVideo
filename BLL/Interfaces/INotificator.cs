using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface INotificator
    {
        Task AboutOrderOpened(string email, Catalog_Order order);

        Task AboutReadyToPick(string email, Catalog_Order order);

        Task AboutOrderInProgress(string email, Catalog_Order order);

        Task AboutOrderColsed(string email, Catalog_Order order);

    }
}
