using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace nVideo.DATA.ControllerModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Укажите Email")]
        [EmailAddress]
        [Remote(action: "VerifyEmail", controller: "Account", ErrorMessage = "User wich such login already exist")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль"),
         StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 6),
        Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите введённый выше пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Введённые пароли не совпадают")]
        public string ConfirmPassword { get; set; }

    }
}
