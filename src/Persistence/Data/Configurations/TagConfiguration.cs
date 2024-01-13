using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.HasMany(x => x.Posts).WithMany(t => t.Tags).UsingEntity(j => j.ToTable("PostTags"));
    }
}