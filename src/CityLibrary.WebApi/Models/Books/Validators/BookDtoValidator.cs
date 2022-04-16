using FluentValidation;

namespace CityLibrary.WebApi.Models.Books.Validators;

public class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator()
    {
        RuleFor(b => b.Name).Length(1, 500);
        RuleFor(b => b.Author).NotNull().NotEmpty();
        RuleFor(b => b.Genre).NotNull().NotEmpty();
    }
}