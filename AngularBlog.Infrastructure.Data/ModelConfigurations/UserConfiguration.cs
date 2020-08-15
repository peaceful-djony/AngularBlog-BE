using AngularBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularBlog.Infrastructure.Data.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");

            entity.HasKey(u => u.Id);

            entity.HasIndex(u => u.Email)
                .IsUnique();

            entity.Property(u => u.Email)
                .HasMaxLength(64)
                .IsRequired();
            
            entity.Property(u => u.FirstName)
                .HasMaxLength(64)
                .HasDefaultValue("")
                .IsRequired();
            
            entity.Property(u => u.LastName)
                .HasMaxLength(64)
                .HasDefaultValue("")
                .IsRequired();

            entity.Property(u => u.Password)
                .HasMaxLength(64)
                .IsRequired();

            entity.HasMany(u => u.Posts)
                .WithOne(p => p.Author);

            entity.HasData(
                new User {Id = 1, Email = "admin@winzep.com", Password = "admin"},
                new User {Id = 2, Email = "blogger@winzep.com", Password = "blogger"}
            );
        }
    }
}