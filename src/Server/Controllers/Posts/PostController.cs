using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Posts;

namespace Server.Controllers.Posts;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;    
    }

    [HttpGet]
    public async Task<PostResult.Index> GetIndex([FromQuery] PostRequest.Index request)
    {
        return await postService.GetIndexAsync(request);
    }
}
