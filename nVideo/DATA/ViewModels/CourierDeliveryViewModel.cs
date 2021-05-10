using nVideo.DATA.ControllerModels;
using nVideo.Models;

namespace nVideo.DATA.ViewModels
{
    public class CourierDeliveryViewModel
    {
        public UserProfile Profile { get; set; }
        public bool IsAuth => Profile != null;

        public CourierDeliveryViewModel(UserProfile profile)
        {
            Profile = profile;
        }
    }
}