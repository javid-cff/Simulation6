using DigiMediaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiMediaMVC.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);
            builder.Property(x => x.ImagePath).IsRequired();

            builder.HasOne(x => x.Speciality).WithMany(x => x.Projects).HasForeignKey(x => x.SpecialityId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
