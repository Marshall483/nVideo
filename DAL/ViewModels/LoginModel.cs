using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Specify Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Select password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public string ReturnUrl { get; set; }
    }
}
