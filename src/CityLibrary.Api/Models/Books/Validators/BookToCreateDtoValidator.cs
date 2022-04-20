using FluentValidation;

namespace CityLibrary.Api.Models.Books.Validators;

public class BookToCreateDtoValidator : AbstractValidator<NewBookWithAuthorDto>
{
    public BookToCreateDtoValidator()
    {
        RuleFor(b => b.Name).NotNull().NotEmpty().MaximumLength(500);
    }
}
