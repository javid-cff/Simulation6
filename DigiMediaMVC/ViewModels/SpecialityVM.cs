using System.ComponentModel.DataAnnotations;

namespace DigiMediaMVC.ViewModels
{
    public class SpecialityVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty! Please fill the name gap!"), 
            MaxLength(70, ErrorMessage = "Name length must be 70 chracters!")]
        public string Name { get; set; } = string.Empty;
    }
}
