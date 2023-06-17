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
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("ticket");

            entity.HasIndex(e => e.FkRouteT, "fk_route_idx");

            entity.HasIndex(e => e.TicketId, "ticket_id_UNIQUE").IsUnique();

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.FkRouteT).HasColumnName("fk_route_t");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Seat).HasColumnName("seat");

            entity.HasOne(d => d.FkRouteTNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FkRouteT)
                .HasConstraintName("fk_route_t");

            entity.HasOne(d => d.FkUserNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FkUser)
                .HasConstraintName("fk_user");
        }
    }
}
