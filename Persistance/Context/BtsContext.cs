using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
