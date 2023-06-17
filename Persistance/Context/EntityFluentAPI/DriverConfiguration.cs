using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Persistance.Context.EntityFluentAPI
{
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> entity)
        {
            entity.HasKey(e => e.DriverId).HasName("PRIMARY");

            entity.ToTable("driver");

            entity.HasIndex(e => e.DriverId, "driver_id_UNIQUE").IsUnique();

            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        }
    }
}
