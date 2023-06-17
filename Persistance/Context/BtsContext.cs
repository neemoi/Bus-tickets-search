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

        modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();

        modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();

        modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new DriverConfiguration());
        
        modelBuilder.ApplyConfiguration(new RouteConfiguration());
        
        modelBuilder.ApplyConfiguration(new SheduleConfiguration());
        
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        
        modelBuilder.ApplyConfiguration(new TransportConfiguration());

        //modelBuilder.Entity<Driver>(entity =>
        //{
        //    entity.HasKey(e => e.DriverId).HasName("PRIMARY");

        //    entity.ToTable("driver");

        //    entity.HasIndex(e => e.DriverId, "driver_id_UNIQUE").IsUnique();

        //    entity.Property(e => e.DriverId).HasColumnName("driver_id");
        //    entity.Property(e => e.Name)
        //        .HasMaxLength(45)
        //        .HasColumnName("name");
        //    entity.Property(e => e.Surname)
        //        .HasMaxLength(45)
        //        .HasColumnName("surname");
        //});

        //modelBuilder.Entity<Route>(entity =>
        //{
        //    entity.HasKey(e => e.RouteId).HasName("PRIMARY");

        //    entity.ToTable("route");

        //    entity.HasIndex(e => e.FkDriver, "driver_id_idx");

        //    entity.HasIndex(e => e.FkShedule, "fk_shedule_idx");

        //    entity.HasIndex(e => e.FkTransport, "transport_id_idx");

        //    entity.Property(e => e.RouteId).HasColumnName("route_id");
        //    entity.Property(e => e.Distance).HasColumnName("distance");
        //    entity.Property(e => e.EndLocation)
        //        .HasMaxLength(45)
        //        .HasColumnName("end_location");
        //    entity.Property(e => e.FkDriver).HasColumnName("fk_driver");
        //    entity.Property(e => e.FkShedule).HasColumnName("fk_shedule");
        //    entity.Property(e => e.FkTransport).HasColumnName("fk_transport");
        //    entity.Property(e => e.StartLocation)
        //        .HasMaxLength(45)
        //        .HasColumnName("start_location");

        //    entity.HasOne(d => d.FkDriverNavigation).WithMany(p => p.Routes)
        //        .HasForeignKey(d => d.FkDriver)
        //        .HasConstraintName("fk_driver");

        //    entity.HasOne(d => d.FkSheduleNavigation).WithMany(p => p.Routes)
        //        .HasForeignKey(d => d.FkShedule)
        //        .HasConstraintName("fk_shedule");

        //    entity.HasOne(d => d.FkTransportNavigation).WithMany(p => p.Routes)
        //        .HasForeignKey(d => d.FkTransport)
        //        .HasConstraintName("fk_transport");
        //});

        //modelBuilder.Entity<Shedule>(entity =>
        //{
        //    entity.HasKey(e => e.SheduleId).HasName("PRIMARY");

        //    entity.ToTable("shedule");

        //    entity.HasIndex(e => e.SheduleId, "shedule_id_UNIQUE").IsUnique();

        //    entity.Property(e => e.SheduleId).HasColumnName("shedule_id");
        //    entity.Property(e => e.ArrivalTime)
        //        .HasColumnType("time")
        //        .HasColumnName("arrival_time");
        //    entity.Property(e => e.Date).HasColumnName("date");
        //    entity.Property(e => e.DepartureTime)
        //        .HasColumnType("time")
        //        .HasColumnName("departure_time");
        //});

        //modelBuilder.Entity<Ticket>(entity =>
        //{
        //    entity.HasKey(e => e.TicketId).HasName("PRIMARY");

        //    entity.ToTable("ticket");

        //    entity.HasIndex(e => e.FkRouteT, "fk_route_idx");

        //    entity.HasIndex(e => e.TicketId, "ticket_id_UNIQUE").IsUnique();

        //    entity.Property(e => e.TicketId).HasColumnName("ticket_id");
        //    entity.Property(e => e.FkRouteT).HasColumnName("fk_route_t");
        //    entity.Property(e => e.Price).HasColumnName("price");
        //    entity.Property(e => e.Seat).HasColumnName("seat");

        //    entity.HasOne(d => d.FkRouteTNavigation).WithMany(p => p.Tickets)
        //        .HasForeignKey(d => d.FkRouteT)
        //        .HasConstraintName("fk_route_t");
        //});

        //modelBuilder.Entity<Transport>(entity =>
        //{
        //    entity.HasKey(e => e.TransportId).HasName("PRIMARY");

        //    entity.ToTable("transport");

        //    entity.HasIndex(e => e.Number, "number_UNIQUE").IsUnique();

        //    entity.HasIndex(e => e.TransportId, "transport_id_UNIQUE").IsUnique();

        //    entity.Property(e => e.TransportId).HasColumnName("transport_id");
        //    entity.Property(e => e.Color)
        //        .HasMaxLength(20)
        //        .HasColumnName("color");
        //    entity.Property(e => e.Model)
        //        .HasMaxLength(20)
        //        .HasColumnName("model");
        //    entity.Property(e => e.Number)
        //        .HasMaxLength(10)
        //        .HasColumnName("number");
        //});

        //modelBuilder.Entity<User>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PRIMARY");

        //    entity.ToTable("user");

        //    entity.HasIndex(e => e.Id, "user_id_UNIQUE").IsUnique();

        //    entity.Property(e => e.Id).HasColumnName("user_id");
        //    entity.Property(e => e.Password)
        //       .HasMaxLength(30)
        //       .HasColumnName("password");
        //    entity.Property(e => e.Surname)
        //        .HasMaxLength(28)
        //        .HasColumnName("surname");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
