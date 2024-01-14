using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Posts;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Controllers.Posts;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;    
    }

    [SwaggerOperation("Returns a list of products available in the bogus catalog.")]
    [HttpGet, AllowAnonymous]
    public async Task<PostResult.Index> GetIndex([FromQuery] PostRequest.Index request)
    {
        return await postService.GetIndexAsync(request);
    }

    [SwaggerOperation("Returns a specific product available in the bogus catalog.")]
    [HttpGet("{productId}"), AllowAnonymous]
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
