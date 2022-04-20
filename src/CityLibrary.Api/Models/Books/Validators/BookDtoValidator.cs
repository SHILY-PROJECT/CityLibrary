using FluentValidation;

namespace CityLibrary.Api.Models.Books.Validators;

public class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator()
    {
        RuleFor(b => b.Name).NotNull().NotEmpty().MaximumLength(500);
        RuleFor(b => b.Author).NotNull().NotEmpty();
        RuleFor(b => b.Genre).NotNull().NotEmpty();
    }
}