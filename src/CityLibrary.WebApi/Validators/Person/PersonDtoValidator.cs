using FluentValidation;
using CityLibrary.WebApi.Models.Person;

namespace CityLibrary.WebApi.Validators.Person;

public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(p => p.FirstName).Length(2, 50);
        RuleFor(p => p.LastName).Length(2, 50);
        RuleFor(p => p.Email).EmailAddress();
    }
}