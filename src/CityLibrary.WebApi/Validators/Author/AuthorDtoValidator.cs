using FluentValidation;
using CityLibrary.WebApi.Models.Author;

namespace CityLibrary.WebApi.Validators.Author;

public class AuthorDtoValidator : AbstractValidator<AuthorDto>
{
    public AuthorDtoValidator()
    {
        RuleFor(a => a.FirstName).Length(2, 50);
        RuleFor(a => a.LastName).Length(2, 50);
        RuleFor(a => a.MiddleName).MaximumLength(50);
    }
}