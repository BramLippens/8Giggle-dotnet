namespace Shared.Posts;

public interface IPostService
{
    Task<PostResult.Index> GetIndexAsync(PostRequest.Index request);
    Task<PostResult.Detail> GetDetailAsync(string request);
    Task<PostResult.Create> CreateAsync(PostRequest.Create request);
}
