using System.Linq;
using FluentValidation;

namespace CityLibrary.Api.Models.Persons.Validators;

public class PersonForDeleteDtoValidator : AbstractValidator<PersonForDeleteDto>
{
    public PersonForDeleteDtoValidator()
    {
        RuleFor(p => new[] { p.FirstName, p.LastName, p.MiddleName, p.Email })
            .Must(p => p.Aggregate((acc, val) => acc + val).Any(c => char.IsLetter(c)))
            .WithMessage("The query must consist of at least one character.");
        RuleFor(p => p.Email).EmailAddress();
    }
}