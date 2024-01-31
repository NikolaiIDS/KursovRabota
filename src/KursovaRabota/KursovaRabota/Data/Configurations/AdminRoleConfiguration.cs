using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota.Data.Configurations
{
    public class AdminRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "6160e632-043f-4e6b-aba3-5e3d4d32d934", // RoleId for "Admin" from the AspNetRoles table
                UserId = "9de92530-126f-44fe-8846-f5099e0e1cc3"   // UserId for "admin" from the AspNetUsers table
            });
        }
    }
}
