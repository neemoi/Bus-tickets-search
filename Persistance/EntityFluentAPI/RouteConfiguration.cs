using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Persistance.EntityFluentAPI
{
    internal class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> entity)
        {
            entity.HasKey(e => e.RouteId).HasName("PRIMARY");

            entity.ToTable("route");

            entity.HasIndex(e => e.FkDriver, "driver_id_idx");

            entity.HasIndex(e => e.FkShedule, "fk_shedule_idx");

            entity.HasIndex(e => e.FkTransport, "transport_id_idx");

            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.EndLocation)
                .HasMaxLength(45)
                .HasColumnName("end_location");
            entity.Property(e => e.FkDriver).HasColumnName("fk_driver");
            entity.Property(e => e.FkShedule).HasColumnName("fk_shedule");
            entity.Property(e => e.FkTransport).HasColumnName("fk_transport");
            entity.Property(e => e.StartLocation)
                .HasMaxLength(45)
                .HasColumnName("start_location");

            entity.HasOne(d => d.FkDriverNavigation).WithMany(p => p.Routes)
                .HasForeignKey(d => d.FkDriver)
                .HasConstraintName("fk_driver");

            entity.HasOne(d => d.FkSheduleNavigation).WithMany(p => p.Routes)
                .HasForeignKey(d => d.FkShedule)
                .HasConstraintName("fk_shedule");

            entity.HasOne(d => d.FkTransportNavigation).WithMany(p => p.Routes)
                .HasForeignKey(d => d.FkTransport)
                .HasConstraintName("fk_transport");
        }
    }
}
