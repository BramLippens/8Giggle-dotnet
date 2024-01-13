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
    public Task<PostResult.Index> GetIndex([FromQuery] PostRequest.Index request)
    {
        return postService.GetIndexAsync(request);
    }

    [HttpGet("{Id}")]
    public Task<PostResult.Detail> GetDetail([FromRoute] PostRequest.Detail request)
    {
        return postService.GetDetailAsync(request.Id);
    }

    [HttpPost]
    public Task<PostResult.Create> Create([FromBody] PostRequest.Create request)
    {
        return postService.CreateAsync(request);
    }
}
