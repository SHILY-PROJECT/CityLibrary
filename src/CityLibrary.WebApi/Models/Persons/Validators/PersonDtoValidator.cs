using FluentValidation;

namespace CityLibrary.WebApi.Models.Persons.Validators;

public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(p => p.FirstName).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
    }
}