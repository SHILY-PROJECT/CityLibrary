using FluentValidation;
using CityLibrary.WebApi.Models.Author;

namespace CityLibrary.WebApi.Validators.Author;

public class AuthorForSearchDtoValidator : AbstractValidator<AuthorForSearchDto>
{
    public AuthorForSearchDtoValidator()
    {
        RuleFor(a => a.FirstName).MaximumLength(50);
        RuleFor(a => a.LastName).MaximumLength(50);
        RuleFor(a => a.MiddleName).MaximumLength(50);
    }
}