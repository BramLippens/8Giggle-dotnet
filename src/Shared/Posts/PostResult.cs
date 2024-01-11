namespace Shared.Posts;

public abstract class PostResult
{
    public class Index
    {
        public IEnumerable<PostDto.Index>? Posts { get; set; }
        public int TotalAmount { get; set; }
    }
}