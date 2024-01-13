using FluentValidation.AspNetCore;
using FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Server.Middleware;
using Shared.Posts;
using Service;

namespace Server;

public class StartUp
{
    public IConfiguration Configuration { get; }

    public StartUp(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //database
        services.AddDbContext<GiggleDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("Giggle"))
                   .EnableSensitiveDataLogging(Configuration.GetValue<bool>("Logging:EanbleSqlParameterLogging"));
        });


        // Add services to the container.
        services.AddGiggleServices();
        services.AddValidatorsFromAssemblyContaining<PostDto.Mutate>();
        services.AddFluentValidationAutoValidation();

        //swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(type => type.DeclaringType is null ? $"{type.Name}" : $"{type.DeclaringType?.Name}.{type.Name}");
            options.EnableAnnotations();
        }).AddFluentValidationRulesToSwagger();

        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddScoped<GiggleDataInitializer>();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        GiggleDbContext dbContext, GiggleDataInitializer dataInitializer)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseWebAssemblyDebugging();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        dbContext.Database.Migrate();

        dataInitializer.SeedData();

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseRouting();


        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
    }
}

