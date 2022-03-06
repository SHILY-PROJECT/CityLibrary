using FluentValidation;

namespace WebApi.WebApi.Models.Dto.Persons.Validators
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(person => person.FirstName).Length(2, 50);
            RuleFor(person => person.LastName).Length(2, 50);
            RuleFor(person => person.MiddleName).Length(0, 50);
        }
    }
}
