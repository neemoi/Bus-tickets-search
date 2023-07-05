using Application.MappingProfile;
using Application.MappingProfile.Admin;
using Application.Services.Implementations;
using Application.Services.Implementations.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using Application.Services.Interfaces.IRepository.User;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Repository;
using Persistance.Repository.Admin;
using Persistance.Repository.User;
using WebApi.Controllers.Admin;
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
                options.UseMySql(builder.Configuration.GetConnectionString("ConnectionStrings"),
                new MySqlServerVersion(new Version(8, 0, 23))));
            builder.Services.AddControllersWithViews();

            //Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingDrivers), typeof(MappingRoles),
                typeof(MappingRoutes), typeof(MappingSchedules), typeof(MappingTickets),
                typeof(MappingTransports), typeof(MappingUsers), typeof(MappingAccount),
                typeof(MappingOrderManagement), typeof(MappingUserEdit));

            //Registering Scoped Services
            builder.Services.AddScoped<UserManager<User>>();
            builder.Services.AddScoped<UserManager<User>, UserManager<User>>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDriverService, DriverService>();
            builder.Services.AddScoped<IRouteService, RouteService>();
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ITransportService, TransportService>();

            //Registering Scoped Repositories
            builder.Services.AddScoped<IDriverRepository, DriverRepository>();
            builder.Services.AddScoped<IRouteRepository, RouteRepository>();
            builder.Services.AddScoped<ISñheduleRepository, ScheduleRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ITransportRepository, TransportRepository>();
            builder.Services.AddScoped<IOrderManagementRepository, OrderManagementRepository>();


            //Identity Configuration
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