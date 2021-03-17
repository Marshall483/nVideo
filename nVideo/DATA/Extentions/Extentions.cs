using Microsoft.AspNetCore.Identity;
using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA.Extentions
{
    public static class Extentions
    {
        public static bool IsNameAlreadyExist(this UserManager<User> manager, string email) =>
            manager.FindByEmailAsync(email) == null ? true : false;
    }
}
