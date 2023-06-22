using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace Persistance.EntityFluentAPI
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
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.FkRouteTNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FkRouteT)
                .HasConstraintName("fk_route_t");

            entity.HasOne(d => d.FkRouteTNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FkRouteT)
                .HasConstraintName("fk_route_t");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_id");
        }
    }
}
