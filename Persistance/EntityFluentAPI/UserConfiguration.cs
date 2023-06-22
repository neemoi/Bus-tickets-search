using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace Persistance.EntityFluentAPI
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Id, "user_id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("user_id");
            entity.Property(e => e.Password)
               .HasMaxLength(30)
               .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(28)
                .HasColumnName("surname");
        }
    }
}
