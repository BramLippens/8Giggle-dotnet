using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Shared.Posts;

namespace Service.Posts;

public class PostService : IPostService
{
    private readonly GiggleDbContext dbContext;

    public PostService(GiggleDbContext context)
    {
        dbContext = context;
    }

    public async Task<PostResult.Index> GetIndexAsync(PostRequest.Index request)
    {
        var query = dbContext.Posts.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Searchterm))
        {
            query.Where(x => x.Title.Contains(request.Searchterm, StringComparison.OrdinalIgnoreCase));
        }

        int totalAmount = await query.CountAsync();

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .OrderBy(x => x.CreatedAt)
            .Select(x => new PostDto.Index
            {
                Id = x.Id.ToString(),
                Title = x.Title,
            })
            .ToListAsync();

        var result = new PostResult.Index
        {
            Posts = items,
            TotalAmount = totalAmount,
        };

        return result;
    }

    public async Task<PostResult.Detail> GetDetailAsync(string id)
    {
        PostResult.Detail response = new();
        var post = await dbContext.Posts.Where(x => x.Id.ToString().Equals(id)).Select( x => new PostDto.Detail
        {
            Id = x.Id.ToString(),
            Title = x.Title,
            TagList = x.Tags.Select(x => new TagDto.Index
            {
                Id = x.Id.ToString(),
                Name = x.Name
            }).ToList()
        }).SingleOrDefaultAsync() ?? throw new EntityNotFoundException(nameof(Post), id);
        
        response.Post = post;

        return response;
    }

    public async Task<PostResult.Create> CreateAsync(PostRequest.Create request)
    {
        List<string?> tagIds = request.Post.TagList.Select(x => x.Id).ToList();

        List<Tag> tags = await dbContext.Tags.Where(x => tagIds.Contains(x.Id.ToString())).ToListAsync();

        Post post = new(request.Post.Title);
        foreach(var tag in tags)
        {
            post.AddTag(tag);
        }
        dbContext.Posts.Add(post);
        await dbContext.SaveChangesAsync();

        return new PostResult.Create { Id = post.Id.ToString() };
    }
}