using Application.Services.Implementations;
using Application.Services.Implementations.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.Interfaces.IServices.User;
using Application.Services.MappingProfile;
using Application.Services.MappingProfile.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Repository.Admin;
using Persistance.Repository.User;
using WebApi.CustomExceptionMiddleware;
using WebApi.Models;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Конфигурация сервисов
            builder.Services.AddControllers();
            builder.Services.AddDbContext<BtsContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("ConnectionStrings"),
                new MySqlServerVersion(new Version(8, 0, 23))));
            builder.Services.AddControllersWithViews();

            //Регистрация AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingDrivers), typeof(MappingRoles),
                typeof(MappingRoutes), typeof(MappingSchedules), typeof(MappingTickets),
                typeof(MappingTransports), typeof(MappingUsers), typeof(MappingAccount),
                typeof(MappingOrderManagement), typeof(MappingUserEdit));

            //Регистрация Scoped сервисов
            builder.Services.AddScoped<UserManager<User>>();
            builder.Services.AddScoped<UserManager<User>, UserManager<User>>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAdminRoleService, AdminRoleService>();
            builder.Services.AddScoped<IAdminUserService, AdminUserService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();

            //Регистрация Scoped репозиториев
            builder.Services.AddScoped<RouteRepository>();
            builder.Services.AddScoped<DriverRepository>();
            builder.Services.AddScoped<TransportRepository>();
            builder.Services.AddScoped<ScheduleRepository>();
            builder.Services.AddScoped<TicketRepository>();
            builder.Services.AddScoped<OrderManagementRepository>();

            //Конфигурация Identity
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BtsContext>()
                .AddRoles<IdentityRole>();

            //Конфигурация Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //Построение приложения
            var app = builder.Build();

            //Режим разработки
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Промежуточное ПО
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            //Маршрутизация для контроллеров
            app.MapControllers();
            
            //Обработчик исключений
            app.ConfigureCustomExceptionMiddleware();

            app.Run();
        }
    }
}