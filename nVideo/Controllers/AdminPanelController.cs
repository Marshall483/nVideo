using Microsoft.AspNetCore.Mvc;

namespace nVideo.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}