using FluentValidation;

namespace CityLibrary.Api.Models.Persons.Validators;

public class LibraryCardDtoValidator : AbstractValidator<LibraryCardDto>
{
    public LibraryCardDtoValidator()
    {
        RuleFor(lc => lc.Person).NotNull().NotEmpty();
        RuleFor(lc => lc.Book).NotNull().NotEmpty();
    }
}