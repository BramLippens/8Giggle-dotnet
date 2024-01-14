using Microsoft.AspNetCore.Components;
using Shared.Posts;

namespace Client.Posts.Components;

public partial class PostListItem
{
    [Parameter, EditorRequired]
    public PostDto.Index Post { get; set; } = default !;

    [Inject] public NavigationManager NavigationManager { get; set; } = default!;
    private void NavigateToDetail()
    {
        NavigationManager.NavigateTo($"post/{Post.Id}");
    }
}