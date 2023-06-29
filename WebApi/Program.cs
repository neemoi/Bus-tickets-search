using Application.Services;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Application.Services.Interfaces.IServices;
using Application.Services.MappingProfile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Repository;
using Persistance.Repository.Admin;
using WebApi.CustomExceptionMiddleware;
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

            builder.Services.AddAutoMapper(typeof(AppMappingProfile));
            builder.Services.AddScoped<UserManager<User>>();
            builder.Services.AddScoped<UserManager<User>, UserManager<User>>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAdminRoleService, AdminRoleService>();
            builder.Services.AddScoped<IAdminUserService, AdminUserService>();
            builder.Services.AddScoped<RouteRepository>();
            builder.Services.AddScoped<DriverRepository>();
            builder.Services.AddScoped<TransportRepository>();
            builder.Services.AddScoped<ScheduleRepository>(); 

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

            app.ConfigureCustomExceptionMiddleware();

            app.Run();
        }
    }
}