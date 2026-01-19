namespace DigiMediaMVC.Models
{
    public class Speciality : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
