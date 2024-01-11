namespace Shared.Posts;

public interface IPostService
{
    Task<PostResult.Index> GetIndexAsync(PostRequest.Index request);
}
