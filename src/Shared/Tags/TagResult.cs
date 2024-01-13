using Shared.Posts;

namespace Shared.Tags;

public abstract class TagResult
{
    public class Index
    {
        public List<TagDto.Index>? Tags { get; set; }
    }
}