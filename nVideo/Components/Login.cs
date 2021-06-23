using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModels;

namespace nVideo.Components
{
    public class Login : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(){
                return Task.Run( () => (IViewComponentResult)
                    View("LoginForm", new LoginModel()));
        }
    }
}
