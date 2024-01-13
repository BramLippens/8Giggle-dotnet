using Microsoft.AspNetCore.Mvc;
using Shared.Tags;

namespace Server.Controllers.Posts;

[ApiController]
[Route("[controller]")]
public class TagController : ControllerBase
{
    private readonly ITagService tagService;
    public TagController(ITagService tagService)
    {
        this.tagService = tagService;
    }

    [HttpGet]
    public Task<TagResult.Index> GetIndex([FromQuery] TagRequest.Index request)
    {
        return tagService.GetIndexAsync(request);
    }
}
