using KursovaRabota.Data.Configurations;
using KursovaRabota.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new UsersConfiguration());
            builder.ApplyConfiguration(new SubjectConfiguration());
            builder.ApplyConfiguration(new CompetitionTypeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}