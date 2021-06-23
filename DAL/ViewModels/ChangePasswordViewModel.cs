using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Required field.")]
        [MaxLength(50, ErrorMessage = "Max length (50) exceeded.")]
        [MinLength(6, ErrorMessage = "Min length 6.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Enter new password")]
        [MaxLength(50, ErrorMessage = "Max length (50) exceeded.")]
        [MinLength(6, ErrorMessage = "Min length 6.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm new password")]
        [MaxLength(50, ErrorMessage = "Max length (50) exceeded.")]
        [MinLength(6, ErrorMessage = "Min length 6.")]
        [Compare("NewPassword", ErrorMessage = "Passwords not match!")]
        [DataType(DataType.Password)]
        public string RepeatNewPassword { get; set; }
    }
}
