using Microsoft.AspNetCore.Mvc;

namespace nVideo.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminPanelController : Controller
    {
        // GET
        public IActionResult Index()
        {
            
            return View();
        }
    }
}