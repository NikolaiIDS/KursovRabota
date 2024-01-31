using System.ComponentModel.DataAnnotations;

using KursovaRabota.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KursovaRabota.Data.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser 
            { 
                Id = "9de92530-126f-44fe-8846-f5099e0e1cc3",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@email.com",
                UserName = "admin",
                NormalizedEmail = "admin@email.com".Normalize(),
                NormalizedUserName = "admin".Normalize(),
            };
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHasher.HashPassword(null, "Aa123456!");
            

            builder.HasData(admin);
        }
    }
}
