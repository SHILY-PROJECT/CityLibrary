using FluentValidation;

namespace CityLibrary.Api.Models.Authors.Validators;

public class AuthorDtoValidator : AbstractValidator<AuthorDto>
{
    public AuthorDtoValidator()
    {
        RuleFor(a => a.FirstName).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(a => a.LastName).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(a => a.MiddleName).MaximumLength(50);
    }
}