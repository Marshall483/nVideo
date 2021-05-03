using Microsoft.AspNetCore.Http;

namespace nVideo.DATA.ViewModels
{
    public class ChangeAvatarViewModel
    {
        public string Error { get; set; }
        public IFormFile Avatar { get; set; } 
    }
}