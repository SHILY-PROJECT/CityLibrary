using FluentValidation;
using CityLibrary.WebApi.Models;

namespace CityLibrary.WebApi.Validators;

public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(p => p.FirstName).Length(2, 50);
        RuleFor(p => p.LastName).Length(2, 50);
        RuleFor(p => p.Email).EmailAddress();
    }
}