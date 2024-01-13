namespace Shared.Tags;

public interface ITagService
{
    Task<TagResult.Index> GetIndexAsync(TagRequest.Index request);
}