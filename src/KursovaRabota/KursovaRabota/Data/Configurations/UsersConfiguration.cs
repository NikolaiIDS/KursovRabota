using KursovaRabota.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var teacher = new ApplicationUser
            {
                Id = "9de92530-126f-44fe-8846-f5099e0e1cc4",
                FirstName = "teacher",
                LastName = "teacher",
                Email = "teacher@email.com",
                UserName = "teacher",
                NormalizedEmail = "teacher@email.com".Normalize(),
                NormalizedUserName = "teacher".Normalize(),
                Approved = true
            };
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            teacher.PasswordHash = passwordHasher.HashPassword(null, "Aa123456!");

            var student = new ApplicationUser
            {
                Id = "9de92530-126f-44fe-8846-f5099e0e1cc5",
                FirstName = "student",
                LastName = "student",
                Email = "student@email.com",
                UserName = "student",
                NormalizedEmail = "student@email.com".Normalize(),
                NormalizedUserName = "student".Normalize(),
                Approved = true
            };

            student.PasswordHash = passwordHasher.HashPassword(null, "Aa123456!");

            builder.HasData(teacher, student);
        }
    }

}
