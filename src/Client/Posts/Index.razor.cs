using Microsoft.AspNetCore.Components;
using Shared.Posts;

namespace Client.Posts;

public partial class Index
{
    [Inject]
    public IPostService PostService { get; set; } = default!;
    private IEnumerable<PostDto.Index>? posts;

    protected override async Task OnInitializedAsync()
    {
        PostRequest.Index request = new();
        var response = await PostService.GetIndexAsync(request);
        posts = response.Posts;
    }
}