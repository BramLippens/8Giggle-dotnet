using Domain.Posts;

namespace Fakers.Posts;

public class TagFaker : EntityFaker<Tag>
{
    public TagFaker() : base()
    {
        CustomInstantiator(f => new Tag(f.Lorem.Word()));
    }
}