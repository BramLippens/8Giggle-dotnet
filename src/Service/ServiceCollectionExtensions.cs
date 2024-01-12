using Microsoft.Extensions.DependencyInjection;
using Service.Posts;
using Shared.Posts;

namespace Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGiggleServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        // Add more services here...

        return services;
    }
}