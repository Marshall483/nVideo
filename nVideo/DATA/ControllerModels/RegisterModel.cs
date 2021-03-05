using System.ComponentModel.DataAnnotations;

namespace nVideo.DATA.ControllerModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Укажите Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль"),
         RegularExpression(@"(?=.*[0-9])(?=.*[a-z])[0-9a-zA-Z]{6,}",
         ErrorMessage = "Пароль должен быть длинее 6и символов."),
        Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите введённый выше пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Введённые пароли не совпадают")]
        public string ConfirmPassword { get; set; }

    }
}
