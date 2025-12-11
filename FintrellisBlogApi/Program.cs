using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FintrellisBlogApi.Data;
using FintrellisBlogApi.Services;
using FintrellisBlogApi.Middleware;
using FintrellisBlogApi.Validators;
using FintrellisBlogApi.Entities;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));


builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Fintrellis Blog API",
        Version = "v1",
        Description = "A RESTful API for managing blog posts with CRUD operations",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Fintrellis Developer",
            Email = "developer@fintrellis.com"
        }
    });
});

// SQLite Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePostDtoValidator>();

// Register Services
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fintrellis Blog API v1");
        c.RoutePrefix = "swagger";
    });

    app.Logger.LogInformation("Running in Development environment");
}

app.UseCors("AllowAll");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        await dbContext.Database.EnsureCreatedAsync();
        app.Logger.LogInformation("Database ensured/created successfully");

        if (!dbContext.Posts.Any())
        {
            app.Logger.LogInformation("Seeding initial data...");

            dbContext.Posts.AddRange(
                new Post
                {
                    Title = "Welcome to Fintrellis Blog",
                    Content = "This is the first post in our amazing blog system.",
                    Author = "Admin",
                    CreatedAt = DateTime.UtcNow.AddDays(-2)
                },
                new Post
                {
                    Title = "Building RESTful APIs with .NET 8",
                    Content = "Learn how to build modern RESTful APIs.",
                    Author = "Tech Lead",
                    CreatedAt = DateTime.UtcNow.AddDays(-1)
                },
                new Post
                {
                    Title = "The Future of FinTech",
                    Content = "Exploring the latest trends in financial technology.",
                    Author = "Finance Expert",
                    CreatedAt = DateTime.UtcNow
                }
            );

            await dbContext.SaveChangesAsync();
            app.Logger.LogInformation("Database seeded with 3 posts");
        }
        else
        {
            var postCount = await dbContext.Posts.CountAsync();
            app.Logger.LogInformation("Database already contains {Count} posts", postCount);
        }
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Error seeding database");
        throw;
    }
}

app.Logger.LogInformation("Fintrellis Blog API started successfully");
app.Logger.LogInformation("Environment: {Environment}", app.Environment.EnvironmentName);
app.Logger.LogInformation("API URL: http://localhost:5299");
app.Logger.LogInformation("Swagger URL: http://localhost:5299/swagger");

app.Run();

public partial class Program { }