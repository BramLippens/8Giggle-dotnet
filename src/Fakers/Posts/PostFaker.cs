using Domain.Posts;

namespace Fakers.Posts;

public class PostFaker : EntityFaker<Post>
{
    public PostFaker() : base()
    {
        CustomInstantiator(f => new Post(f.Lorem.Sentence()));
    }
}