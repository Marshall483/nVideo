using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nVideo.DATA;
using nVideo.DATA.Extentions;
using nVideo.DATA.ViewModels;
using nVideo.Migrations;
using nVideo.Models;

namespace nVideo.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager; 
        
        static readonly string CourierDelivery = "Courier Delivery";
        static readonly string SelfDelivery = "Self Delivery";
        
        public OrderController(AppDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> ProcessOrder(string deliveryType) 
        {
            if (deliveryType == CourierDelivery)
            {
                if (User.Identity.IsAuthenticated) 
                    return View(CourierDelivery,
                        new CourierDeliveryViewModel(_userManager.GetUserIncludeProfile
                            (new ClaimsPrincipal(User.Identities)).Profile));
                
                return View(CourierDelivery, new CourierDeliveryViewModel(null));
            }
            // If Self del., not interesting auth or not.
            return View(SelfDelivery, new SelfDeliveryViewModel(_dbContext.Cities));
        }
        
        [HttpPost]
        public IActionResult ProcessSelfDelivery(string cityId)
        {
            return Ok("ZBS");
        }
        
        [HttpPost]
        public IActionResult ProcessCourierDelivery(UserProfile customer)
        {
            return Ok("Congratulations, you make a order!");
        }
    }
}