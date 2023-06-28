using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace Persistance.EntityFluentAPI
{
    internal class SheduleConfiguration : IEntityTypeConfiguration<Sсhedule>
    {
        public void Configure(EntityTypeBuilder<Sсhedule> entity)
        {
            entity.HasKey(e => e.SсheduleId).HasName("PRIMARY");

            entity.ToTable("shedule");

            entity.HasIndex(e => e.SсheduleId, "shedule_id_UNIQUE").IsUnique();

            entity.Property(e => e.SсheduleId).HasColumnName("shedule_id");
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
