using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA.ControllerModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Incorrect password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Enter new password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Reenter new password")]
        [DataType(DataType.Password)]
        [Compare("RepeatNewPassword", ErrorMessage = "Passwords not match!")]
        public string RepeatNewPassword { get; set; }
    }
}
