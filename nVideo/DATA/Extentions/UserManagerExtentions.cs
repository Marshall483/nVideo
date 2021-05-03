using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using nVideo.Models;

namespace nVideo.DATA.Extentions
{
    public static class UserManagerExtentions
    {
        public static bool IsNameAlreadyExist(this UserManager<User> manager, string email) =>
            manager.FindByEmailAsync(email) == null;

        public static async Task<User> GetUserAsync(this UserManager<User> manager, ClaimsPrincipal principal) =>
            await manager.GetUserAsync(principal);

        public static User GetUserIncludeProfile(this UserManager<User> manager,
            ClaimsPrincipal principal) =>
            manager.Users
                .Where(u => u.Id.Equals(manager.GetUserId(principal)))
                .Include(u => u.Profile)
                .Single();

    }
}
