using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using restaurant3.Models;
using Microsoft.AspNetCore.Identity;
using restaurant3.Data;


namespace ProjetDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BdNaamiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BdNaamiContextConnection")));

            builder.Services.AddDbContext<restaurant3Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("restaurant3ContextConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<restaurant3Context>();

            builder.Services.AddRazorPages();

            var app = builder.Build();

            app.MapRazorPages();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.Run();
        }
    }
}