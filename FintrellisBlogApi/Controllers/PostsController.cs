using Microsoft.AspNetCore.Mvc;
using FintrellisBlogApi.Services;
using FintrellisBlogApi.DTOs;

namespace FintrellisBlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto createPostDto)
        {
            var post = await _postService.CreatePostAsync(createPostDto);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostDto>> UpdatePost(int id, UpdatePostDto updatePostDto)
        {
            var post = await _postService.UpdatePostAsync(id, updatePostDto);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var deleted = await _postService.DeletePostAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}