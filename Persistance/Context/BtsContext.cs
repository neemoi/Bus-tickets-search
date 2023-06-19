using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityFluentAPI;

namespace WebApi.Models;

public partial class BtsContext : IdentityDbContext<User>
{ 
    public BtsContext() { }

    public BtsContext(DbContextOptions<BtsContext> options)
        : base(options) { }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Shedule> Shedules { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=bts;uid=admin;pwd=admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new IdentityUserTokenConfiguration());

        modelBuilder.ApplyConfiguration(new IdentityUserRoleConfiguration());

        modelBuilder.ApplyConfiguration(new IdentityUserLoginConfiguration());

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new DriverConfiguration());
        
        modelBuilder.ApplyConfiguration(new RouteConfiguration());
        
        modelBuilder.ApplyConfiguration(new SheduleConfiguration());
        
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        
        modelBuilder.ApplyConfiguration(new TransportConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
