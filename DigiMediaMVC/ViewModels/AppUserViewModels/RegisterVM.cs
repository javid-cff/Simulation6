using System.ComponentModel.DataAnnotations;

namespace DigiMediaMVC.ViewModels.AppUserViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Username can not be empty!"),
            MaxLength(255, ErrorMessage = "Username length must be maximum 255 characters!"),
                MinLength(3, ErrorMessage = "Username length must be minimum 3 characters!")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Fullname can not be empty!"),
            MaxLength(255, ErrorMessage = "Fullname length must be maximum 255 characters!"),
                MinLength(3, ErrorMessage = "Fullname length must be minimum 3 characters!")]
        public string Fullname { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email can not be empty!"), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password can not be empty!"),
            MaxLength(255, ErrorMessage = "Password length must be maximum 255 characters!"),
                MinLength(8, ErrorMessage = "Password length must be minimum 8 characters!"), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
