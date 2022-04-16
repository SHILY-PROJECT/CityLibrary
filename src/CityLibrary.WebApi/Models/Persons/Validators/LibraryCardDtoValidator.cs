using FluentValidation;

namespace CityLibrary.WebApi.Models.Persons.Validators;

public class LibraryCardDtoValidator : AbstractValidator<LibraryCardDto>
{
    public LibraryCardDtoValidator()
    {
        RuleFor(lc => lc.Person).NotNull().NotEmpty();
        RuleFor(lc => lc.Book).NotNull().NotEmpty();
    }
}