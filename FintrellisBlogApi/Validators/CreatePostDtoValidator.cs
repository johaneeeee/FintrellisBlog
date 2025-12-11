using FluentValidation;
using FintrellisBlogApi.DTOs;

namespace FintrellisBlogApi.Validators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MinimumLength(10).WithMessage("Content must be at least 10 characters");

            RuleFor(x => x.Author)
                .MaximumLength(100).WithMessage("Author name cannot exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.Author));
        }
    }
}