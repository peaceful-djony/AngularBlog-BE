using AngularBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularBlog.Infrastructure.Data.ModelConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.ToTable("Posts");
            
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Title)
                .HasMaxLength(128)
                .IsRequired();
            
            entity.Property(p => p.Author)
                .HasMaxLength(64)
                .IsRequired();
            
            entity.Property(p => p.Content)
                .HasMaxLength(4 * 1024)
                .IsRequired();
            
            entity.Property(p => p.DateTime)
                .IsRequired();
        }
    }
}