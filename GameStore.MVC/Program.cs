using GameStore.BL.Abstractions;
using GameStore.BL.Concretes;
using GameStore.DAL;
using GameStore.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameStore.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 4;
                opt.User.RequireUniqueEmail = true;            
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddDbContext<AppDbContext>(
            options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
            );

            builder.Services.AddScoped<IGameService, GameService>();

            builder.Services.AddScoped<IReviewService, ReviewService>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
