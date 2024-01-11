using Domain.Posts;
using Fakers.Posts;

namespace Persistence;

public class FakeSeeder
{
    private readonly GiggleDbContext dataContext;

    public FakeSeeder(GiggleDbContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public void Seed()
    {
        SeedPosts();
        SeedTags();
    }

    private void SeedTags()
    {
        List<Tag> tags = new();
        {
            new Tag("Funny");
            new Tag("News");
            new Tag("Sad");
            new Tag("Economy");
        };

        dataContext.Tags.AddRange(tags);
        dataContext.SaveChanges();
    }

    private void SeedPosts()
    {
        var posts = new PostFaker().Generate(100);
        dataContext.Posts.AddRange(posts);
        dataContext.SaveChanges();
    }
}