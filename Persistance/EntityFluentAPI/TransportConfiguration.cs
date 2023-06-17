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
    internal class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> entity)
        {
            entity.HasKey(e => e.TransportId).HasName("PRIMARY");

            entity.ToTable("transport");

            entity.HasIndex(e => e.Number, "number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.TransportId, "transport_id_UNIQUE").IsUnique();

            entity.Property(e => e.TransportId).HasColumnName("transport_id");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("color");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .HasColumnName("model");
            entity.Property(e => e.Number)
                .HasMaxLength(10)
                .HasColumnName("number");
        }
    }
}
