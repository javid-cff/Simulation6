using System.ComponentModel.DataAnnotations;

namespace DigiMediaMVC.ViewModels.ProjectViewModels
{
    public class ProjectCreateVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty! Please fill the name gap!"),
            MaxLength(70, ErrorMessage = "Name length must be maximum 70 chracters!"), 
                MinLength(3, ErrorMessage = "Name length must be minimum 3 characters!")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Image can not be empty! Please put your image!")]
        public IFormFile Image { get; set; } = null!;
        [Required(ErrorMessage = "Speciality can not be empty! Please select your speciality!")]
        public int SpecialityId { get; set; }
    }
}
