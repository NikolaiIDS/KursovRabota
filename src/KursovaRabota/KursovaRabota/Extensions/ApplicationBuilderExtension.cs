using KursovaRabota.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace KursovaRabota.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider services = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    IdentityRole adminRole = new IdentityRole("Admin");
                    await roleManager.CreateAsync(adminRole);
                }

                if (!await roleManager.RoleExistsAsync("Teacher"))
                {
                    IdentityRole adminRole = new IdentityRole("Teacher");
                    await roleManager.CreateAsync(adminRole);
                }

                if (!await roleManager.RoleExistsAsync("Student"))
                {
                    IdentityRole userRole = new IdentityRole("Student");
                    await roleManager.CreateAsync(userRole);
                }

                ApplicationUser admin = await userManager.FindByNameAsync("admin");
                await userManager.AddToRoleAsync(admin, "Admin");
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }

}
