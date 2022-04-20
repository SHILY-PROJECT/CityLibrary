using System.Linq;
using FluentValidation;

namespace CityLibrary.WebApi.Models.Authors.Validators;

public class AuthorForSearchDtoValidator : AbstractValidator<AuthorForSearchDto>
{
    public AuthorForSearchDtoValidator()
    {
        RuleFor(a => new[] { a.FirstName, a.LastName, a.MiddleName }.Aggregate((acc, val) => acc + val))
            .NotEmpty().WithMessage("The query must consist of at least one character.")
            .MaximumLength(150);
    }
}