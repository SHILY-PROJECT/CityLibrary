using FluentValidation;

namespace SimbirSoftWorkshop.API.Models.Dto.Books.Validators
{
    public class NewBookDtoValidator : AbstractValidator<NewBookDto>
    {
        public NewBookDtoValidator()
        {
            RuleFor(book => book.Name).Length(1, 500);
            RuleFor(genre => genre.GenreId).InclusiveBetween(1, int.MaxValue);
            RuleFor(author => author.AuthorId).InclusiveBetween(1, int.MaxValue);
        }
    }
}
