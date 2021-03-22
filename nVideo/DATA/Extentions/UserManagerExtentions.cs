using Microsoft.AspNetCore.Identity;
using nVideo.Models;

namespace nVideo.DATA.Extentions
{
    public static class UserManagerExtentions
    {
        public static bool IsNameAlreadyExist(this UserManager<User> manager, string email) =>
            manager.FindByEmailAsync(email) == null ? true : false;
    }
}
