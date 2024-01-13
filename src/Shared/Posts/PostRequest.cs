namespace Shared.Posts;

public abstract class PostRequest
{
    public class Index
    {
        public string? Searchterm { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set;} = 25;
    }
    public class Detail
    {
        public string Id { get; set; }
    }
    public class Create
    {
        public PostDto.Mutate Post { get; set; }
    }
    public class Edit
    {
        public string Id { get; set; }
        public PostDto.Mutate Post { get; set; }
    }
}