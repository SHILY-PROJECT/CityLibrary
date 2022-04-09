using FluentValidation;
using CityLibrary.WebApi.Models;

namespace CityLibrary.WebApi.Validators;

public class LibraryCardDtoValidator : AbstractValidator<LibraryCardDto>
{
    public LibraryCardDtoValidator()
    {
        RuleFor(lc => lc.Person).NotNull().NotEmpty();
        RuleFor(lc => lc.Book).NotNull().NotEmpty();
    }
}