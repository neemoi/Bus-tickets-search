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
    internal class SheduleConfiguration : IEntityTypeConfiguration<Shedule>
    {
        public void Configure(EntityTypeBuilder<Shedule> entity)
        {
            entity.HasKey(e => e.SheduleId).HasName("PRIMARY");

            entity.ToTable("shedule");

            entity.HasIndex(e => e.SheduleId, "shedule_id_UNIQUE").IsUnique();

            entity.Property(e => e.SheduleId).HasColumnName("shedule_id");
            entity.Property(e => e.ArrivalTime)
                .HasColumnType("time")
                .HasColumnName("arrival_time");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DepartureTime)
                .HasColumnType("time")
                .HasColumnName("departure_time");
        }
    }
}
