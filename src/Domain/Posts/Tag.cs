namespace Domain.Posts;

public class Tag:Entity
{
    private string _name = default!;
    public string Name
    {
        get => _name;
        set => _name = Guard.Against.NullOrEmpty(value, nameof(Name));
    }

    private readonly List<Post> _posts = new();
    public IReadOnlyList<Post> Posts => _posts.AsReadOnly();

    private Tag() { }
    public Tag(string name)
    {
        Name = name;
    }
}