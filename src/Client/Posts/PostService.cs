using Shared.Posts;
using System.Net.Http.Json;

namespace Client.Posts;

public class PostService : IPostService
{
    private readonly HttpClient client;
    private const string endpoint = "api/post";

    public PostService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<PostResult.Index> GetIndexAsync(PostRequest.Index request)
    {
        var response = await client.GetFromJsonAsync<PostResult.Index>($"{endpoint}?page=1&pagesize=10");
        return response;
    }

    public Task<PostResult.Detail> GetDetailAsync(string request)
    {
        throw new NotImplementedException();
    }

    public Task<PostResult.Create> CreateAsync(PostRequest.Create request)
    {
        throw new NotImplementedException();
    }
}
