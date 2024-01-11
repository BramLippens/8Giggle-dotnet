using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Posts;

public class Post : Entity
{
    private string _title = default!;
    public string Title
    {
        get => _title;
        set => _title = Guard.Against.NullOrEmpty(value, nameof(Title));
    }

    private readonly List<Tag> _tags = new();
    public IReadOnlyList<Tag> Tags => _tags.AsReadOnly();

    private Post() { }

    public Post(string title)
    {
        Title = title;
    }

    public void AddTag(Tag tag)
    {
        Guard.Against.Null(tag, nameof(tag));
        if(Tags.Contains(tag))
        {
            throw new ApplicationException($"{nameof(Post)} '{_title}' already contains the tag:{tag.Name}");
        }
        _tags.Add(tag);
    }
}