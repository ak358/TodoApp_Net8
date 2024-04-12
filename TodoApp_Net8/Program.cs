using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TodoApp_Net8.Data;

namespace TodoApp_Net8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            //認証のため追加
            //ASP.NET Core Identity を使用せずに cookie 認証を使用する
            //https://learn.microsoft.com/ja-jp/aspnet/core/security/authentication/cookie?view=aspnetcore-8.0
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.Cookie.Name = "auth";
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/access_denied";
                }
             );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Login/AccessDenied");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAntiforgery();//なかったので追加

            //順番大事
            app.UseAuthentication();//認証のため追加
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
