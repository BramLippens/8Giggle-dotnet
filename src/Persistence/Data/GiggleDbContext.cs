using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Data.Triggers;
using System.Reflection;

namespace Persistence.Data;

public class GiggleDbContext : DbContext
{
    public GiggleDbContext(DbContextOptions<GiggleDbContext> options) : base(options)
    {
        
    }
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}