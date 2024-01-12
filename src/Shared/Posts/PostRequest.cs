namespace Shared.Posts;

public abstract class PostRequest
{
    public class Index
    {
        public string? Searchterm { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set;} = 25;
    }
}