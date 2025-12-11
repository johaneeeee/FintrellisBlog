using Microsoft.EntityFrameworkCore;
using FintrellisBlogApi.Data;
using FintrellisBlogApi.Entities;
using FintrellisBlogApi.DTOs;

namespace FintrellisBlogApi.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts.Select(MapToDto).ToList();
        }

        public async Task<PostDto?> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post != null ? MapToDto(post) : null;
        }

        public async Task<PostDto> CreatePostAsync(CreatePostDto createPostDto)
        {
            var post = new Post
            {
                Title = createPostDto.Title,
                Content = createPostDto.Content,
                Author = createPostDto.Author,
                CreatedAt = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return MapToDto(post);
        }

        public async Task<PostDto?> UpdatePostAsync(int id, UpdatePostDto updatePostDto)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return null;

            post.Title = updatePostDto.Title;
            post.Content = updatePostDto.Content;
            post.Author = updatePostDto.Author;
            post.UpdatedAt = DateTime.UtcNow;

            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return MapToDto(post);
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        private static PostDto MapToDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }
    }
}