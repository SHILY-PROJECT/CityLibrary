using FluentValidation;

namespace WebApi.WebApi.Models.Dto.Persons.Validators
{
    public class PersonBookDtoValidator : AbstractValidator<PersonBookDto>
    {
        public PersonBookDtoValidator()
        {
            RuleFor(person => person.PersoneId).InclusiveBetween(1, int.MaxValue);
            RuleFor(book => book.BookId).InclusiveBetween(1, int.MaxValue);
        }
    }
}
