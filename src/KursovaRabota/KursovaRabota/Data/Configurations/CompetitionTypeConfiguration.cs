using KursovaRabota.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Data.Configurations
{
    public class CompetitionTypeConfiguration : IEntityTypeConfiguration<CompetitionType>
    {
        public void Configure(EntityTypeBuilder<CompetitionType> builder)
        {
            var competitionTypes = new List<CompetitionType>
            {
                new CompetitionType { Id = Guid.NewGuid(), Type = "Олимпиада" },
                new CompetitionType { Id = Guid.NewGuid(), Type = "Училищно състезание" },
                new CompetitionType { Id = Guid.NewGuid(), Type = "Областен кръг" },
                new CompetitionType { Id = Guid.NewGuid(), Type = "Национален кръг" }
            };

            builder.HasData(competitionTypes);
        }
    }
}
