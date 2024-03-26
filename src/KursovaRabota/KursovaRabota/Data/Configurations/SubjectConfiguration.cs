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
                new Subject { Id = Guid.Parse("8c7cce8b-25dc-4b62-8181-8e9a25d08075"), SubjectName = "Математика" },
                new Subject { Id = Guid.Parse("f2d0f16e-476f-4796-9b8b-eb2a064c4aa8"), SubjectName = "Български език" },
                new Subject { Id = Guid.Parse("5c07e541-15f7-4d78-be88-d832b22a6a16"), SubjectName = "География" },
                new Subject { Id = Guid.Parse("349c02ab-2ffd-4612-b072-a9424289631b"), SubjectName = "История" }
            };

            builder.HasData(subjects);
        }
    }
}
