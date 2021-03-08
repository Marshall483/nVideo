using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using nVideo.DATA.ControllerModels;

namespace nVideo.Components
{
    public class Login : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(){
                return View("LoginForm", new LoginModel());
        }
    }
}
