using Microsoft.EntityFrameworkCore;
using Persistence;
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
}