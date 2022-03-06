using FluentValidation;

namespace WebApi.WebApi.Models.Dto.Persons.Validators
{
    public class UpdatePersonDtoValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonDtoValidator()
        {
            RuleFor(person => person.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(person => person.FirstName).Length(2, 50);
            RuleFor(person => person.LastName).Length(2, 50);
            RuleFor(person => person.MiddleName).Length(0, 50);
        }
    }
}
