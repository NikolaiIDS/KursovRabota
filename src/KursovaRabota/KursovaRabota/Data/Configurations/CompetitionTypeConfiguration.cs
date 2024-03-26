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
                new CompetitionType { Id = Guid.Parse("2374a7b3-41ad-4d18-9f2b-f291ea349122"), Type = "Олимпиада" },
                new CompetitionType { Id = Guid.Parse("9bd1d73d-9cc4-4786-af65-41de7aef86e1"), Type = "Училищно състезание" },
                new CompetitionType { Id = Guid.Parse("714b850f-3f77-4739-8c27-0638c6ba5ec4"), Type = "Областен кръг" },
                new CompetitionType { Id = Guid.Parse("dc513c92-13a2-431b-bc36-5a1cba5bd9dc"), Type = "Национален кръг" }
            };

            builder.HasData(competitionTypes);
        }
    }
}
