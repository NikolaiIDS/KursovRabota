using KursovaRabota.Data;
using KursovaRabota.Data.Models;
using KursovaRabota.Extensions;
using KursovaRabota.Services;
using KursovaRabota.Services.Contracts;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KursovaRabota
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();
            builder.Services.AddScoped<ICompetitionTypeService, CompetitionTypeService>();
            builder.Services.AddScoped<ICompetitionService, CompetitionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.SeedRoles();

            app.Run();
        }
    }
}