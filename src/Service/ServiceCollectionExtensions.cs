using Microsoft.Extensions.DependencyInjection;
using Service.Posts;
using Shared.Posts;
using Shared.Tags;

namespace Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGiggleServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ITagService, TagService>();
        // Add more services here...

        return services;
    }
}