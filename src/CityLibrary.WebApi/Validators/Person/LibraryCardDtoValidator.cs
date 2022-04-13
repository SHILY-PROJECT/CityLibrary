using FluentValidation;
using CityLibrary.WebApi.Models.Person;

namespace CityLibrary.WebApi.Validators.Person;

public class LibraryCardDtoValidator : AbstractValidator<LibraryCardDto>
{
    public LibraryCardDtoValidator()
    {
        RuleFor(lc => lc.Person).NotNull().NotEmpty();
        RuleFor(lc => lc.Book).NotNull().NotEmpty();
    }
}