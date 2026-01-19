namespace DigiMediaMVC.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; } = null!;
    }
}
