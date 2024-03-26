﻿using KursovaRabota.Data.Models;
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
                Id = "a7594af2-ae37-4217-a1d8-891f590692b3",
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
                Id = "0778238c-1e1b-4e5d-9ea6-1a01e9264086",
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
