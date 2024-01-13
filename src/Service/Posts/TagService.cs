using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Shared.Posts;
using Shared.Tags;

namespace Service.Posts
{
    public class TagService : ITagService
    {
        private readonly GiggleDbContext dbContext;

        public TagService(GiggleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TagResult.Index> GetIndexAsync(TagRequest.Index request)
        {
            var query = dbContext.Tags.AsQueryable();

            var items = await query.Select(x => new TagDto.Index
            {
                Id = x.Id.ToString(),
                Name = x.Name,
            }).ToListAsync();

            var result = new TagResult.Index
            {
                Tags = items,
            };

            return result;
        }
    }
}