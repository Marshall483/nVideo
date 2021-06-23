using Models;

namespace ViewModels
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