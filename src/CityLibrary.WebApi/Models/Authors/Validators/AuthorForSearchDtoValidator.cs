using FluentValidation;

namespace CityLibrary.WebApi.Models.Authors.Validators;

public class AuthorForSearchDtoValidator : AbstractValidator<AuthorForSearchDto>
{
    public AuthorForSearchDtoValidator()
    {
        RuleFor(a => a.FirstName).MaximumLength(50);
        RuleFor(a => a.LastName).MaximumLength(50);
        RuleFor(a => a.MiddleName).MaximumLength(50);
    }
}