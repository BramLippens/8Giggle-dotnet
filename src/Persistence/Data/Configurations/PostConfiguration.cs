using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.HasMany(x => x.Tags).WithMany(t => t.Posts).UsingEntity(j => j.ToTable("PostTags"));
    }
}