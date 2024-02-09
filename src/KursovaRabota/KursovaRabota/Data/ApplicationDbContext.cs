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
            //builder.ApplyConfiguration(new AdminRoleConfiguration());
            //SeedRoles(builder);
            base.OnModelCreating(builder);
        }
        //private static void SeedRoles(ModelBuilder builder)
        //{
        //    var roles = new[]
        //    {
        //        new IdentityRole {Id = "6160e632-043f-4e6b-aba3-5e3d4d32d934", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "ae5ae6c2-548c-401d-b867-3edc9cad611c" },
        //        new IdentityRole {Id="02416159-acb2-4f4d-a58c-f67bd1bde343", Name = "Teacher", NormalizedName = "TEACHER", ConcurrencyStamp = "79020e06-a9a2-4b07-8bad-e87e196496fb" },
        //        new IdentityRole {Id="9647886c-0b29-4e53-a29c-6e261b5f0a82", Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = "56fdaef0-c138-42eb-93f1-5756ad7f647f" }
        //    };

        //    builder.Entity<IdentityRole>().HasData(roles);
        //}
    }
}