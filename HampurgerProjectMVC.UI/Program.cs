using HamburgerProject.BLL.MenuService;
using HamburgerProject.BLL.OrderService;
using HamburgerProject.BLL.SauceService;
using HamburgerProject.BLL.UserService;
using HamburgerProject.CORE.Entities;
using HamburgerProject.REPOSITORY.Concretes;
using HamburgerProject.REPOSITORY.Contexts;
using HamburgerProject.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HampurgerProjectMVC.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var conn = builder.Configuration.GetConnectionString("DefaultConnection-Ev");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(conn);
                options.UseLazyLoadingProxies();
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddTransient<ISauceRepo, SauceRepo>();
            builder.Services.AddTransient<IOrderRepo, OrderRepo>();
            builder.Services.AddTransient<IMenuRepo, MenuRepo>();
            builder.Services.AddTransient<IAppUserRepo, AppUserRepo>();

            builder.Services.AddTransient<ISauceService, SauceService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<IMenuService, MenuService>();
            builder.Services.AddTransient<IUserService, UserService>();

            var a =builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddRoles<IdentityRole>();

            var app = builder.Build();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}