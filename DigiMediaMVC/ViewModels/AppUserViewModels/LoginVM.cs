using System.ComponentModel.DataAnnotations;

namespace DigiMediaMVC.ViewModels.AppUserViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email can not be empty!"), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password can not be empty!"), 
            MaxLength(255, ErrorMessage = "Password length must be maximum 255 characters!"), 
                MinLength(8, ErrorMessage = "Password length must be minimum 8 characters!"), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool IsRemember { get; set; }

    }
}
