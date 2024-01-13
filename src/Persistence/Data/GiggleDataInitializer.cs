using Bogus;
using Domain.Posts;
using Fakers.Posts;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class GiggleDataInitializer
{
    private readonly GiggleDbContext dataContext;
    public GiggleDataInitializer(GiggleDbContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public void SeedData()
    {
        dataContext.Database.EnsureDeleted();
        if (dataContext.Database.EnsureCreated())
        {
            SeedPosts();
        }
    }

    private async void SeedPosts()
    {
        List<Tag> tags = new()
        {
            new Tag("Funny"),
            new Tag("News"),
            new Tag("Sad"),
            new Tag("Economy")
        };

        List<Post> posts = new PostFaker()
            .Generate(100);

        foreach (var item in posts)
        {
            int random = new Random().Next(1, 5);
            for (int i = 0; i < random; i++)
            {
                item.AddTag(tags[i]);
            }
        }
        await dataContext.AddRangeAsync(posts);
        await dataContext.SaveChangesAsync();
    }
}