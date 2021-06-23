using Microsoft.AspNetCore.Http;

namespace ViewModels
{
    public class ChangeAvatarViewModel
    {
        public string Error { get; set; }
        public IFormFile Avatar { get; set; } 
    }
}