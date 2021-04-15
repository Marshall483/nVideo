using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nVideo.Models;

namespace nVideo.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminPanelController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminPanelController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var principal = new ClaimsPrincipal(User.Identities);
            var _admin = await _userManager.GetUserAsync(principal);
            ViewBag.Admin = _admin;
            return View();
        }

        public IActionResult Banhammer()
        {
            return View();
        }

        public IActionResult Ban(string useremail)
        {
            
        }
    }
}