using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Reflection.Emit;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<BtsContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("ConnectionStrings"), new MySqlServerVersion(new Version(8, 0, 23))));

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<UserManager<User>>();
            builder.Services.AddScoped<UserManager<User>, UserManager<User>>();

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BtsContext>()
                .AddRoles<IdentityRole>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}