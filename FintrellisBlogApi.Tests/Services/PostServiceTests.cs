using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using FintrellisBlogApi.Data;
using FintrellisBlogApi.Services;
using FintrellisBlogApi.DTOs;

namespace FintrellisBlogApi.Tests.Services
{
    public class PostServiceTests
    {
        private readonly AppDbContext _dbContext;
        private readonly PostService _postService;

        public PostServiceTests()
        {
            // Setup in-memory database
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;

            _dbContext = new AppDbContext(options);
            _postService = new PostService(_dbContext);
        }

        [Fact]
        public async Task GetAllPostsAsync_ShouldReturnEmptyList_WhenNoPosts()
        {
            // Act
            var result = await _postService.GetAllPostsAsync();

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task CreatePostAsync_ShouldAddPostToDatabase()
        {
            // Arrange
            var createDto = new CreatePostDto
            {
                Title = "Test Post",
                Content = "Test Content for unit testing",
                Author = "Test Author"
            };

            // Act
            var result = await _postService.CreatePostAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            result.Title.Should().Be("Test Post");
        }

        [Fact]
        public async Task GetPostByIdAsync_ShouldReturnPost_WhenExists()
        {
            // Arrange
            var createDto = new CreatePostDto
            {
                Title = "Test for Get",
                Content = "Content",
                Author = "Author"
            };
            var created = await _postService.CreatePostAsync(createDto);

            // Act
            var result = await _postService.GetPostByIdAsync(created.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(created.Id);
            result.Title.Should().Be("Test for Get");
        }

        [Fact]
        public async Task GetPostByIdAsync_ShouldReturnNull_WhenNotExists()
        {
            // Act
            var result = await _postService.GetPostByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }
    }
}