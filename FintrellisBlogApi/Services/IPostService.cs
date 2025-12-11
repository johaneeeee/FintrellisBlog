using FintrellisBlogApi.DTOs;

namespace FintrellisBlogApi.Services
{
    public interface IPostService
    {
        Task<List<PostDto>> GetAllPostsAsync();
        Task<PostDto?> GetPostByIdAsync(int id);
        Task<PostDto> CreatePostAsync(CreatePostDto createPostDto);
        Task<PostDto?> UpdatePostAsync(int id, UpdatePostDto updatePostDto);
        Task<bool> DeletePostAsync(int id);
    }
}