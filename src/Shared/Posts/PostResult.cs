namespace Shared.Posts;

public abstract class PostResult
{
    public class Index
    {
        public IEnumerable<PostDto.Index>? Posts { get; set; }
        public int TotalAmount { get; set; }
    }
    public class Detail
    {
        public PostDto.Detail Post {get; set;}
    }
    public class Delete { }

    public class Create
    {
        public string Id { get; set; }
    }
    public class Update
    {
        public string Id { get; set; }
    }
}