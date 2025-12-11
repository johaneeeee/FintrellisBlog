namespace FintrellisBlogApi.DTOs
{
    public class CreatePostDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Author { get; set; }
    }
}
