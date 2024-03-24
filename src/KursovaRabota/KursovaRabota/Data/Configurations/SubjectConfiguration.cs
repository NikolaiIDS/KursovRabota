using KursovaRabota.Data.Models;
using KursovaRabota.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KursovaRabota.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            var subjects = new List<Subject>
            {
                new Subject { Id = Guid.NewGuid(), SubjectName = "Математика" },
                new Subject { Id = Guid.NewGuid(), SubjectName = "Български език" },
                new Subject { Id = Guid.NewGuid(), SubjectName = "География" },
                new Subject { Id = Guid.NewGuid(), SubjectName = "История" }
            };

            builder.HasData(subjects);
        }
    }
}
