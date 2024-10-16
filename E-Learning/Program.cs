using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Entites.Data;
using Entites.Models;
using Repositories.Interfaces;
using Repositories.Impelmentations;
using Services.Interfaces;
using Services.Impelmentations;
using Microsoft.CodeAnalysis.Options;

namespace E_Learning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<User, IdentityRole>(
                Options=>
                {
                    Options.Password.RequiredUniqueChars = 0;
                    Options.Password.RequireUppercase = false;
                    Options.Password.RequiredLength = 8;
                    Options.Password.RequireNonAlphanumeric = false;
                    Options.Password.RequireLowercase = false;
                }
                )
                .AddEntityFrameworkStores<ElearingDbcontext>().AddDefaultTokenProviders();
            builder.Services.AddTransient<IRepositoryManger, RepositoryManger>();
            builder.Services.AddTransient<IServicesManger, ServicesManger>();
			//builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
		    builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDbContext<ElearingDbcontext>(opion =>
            {
                opion.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
