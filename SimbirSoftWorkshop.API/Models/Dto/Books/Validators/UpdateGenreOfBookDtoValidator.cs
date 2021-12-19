using FluentValidation;

namespace SimbirSoftWorkshop.API.Models.Dto.Books.Validators
{
    public class UpdateGenreOfBookDtoValidator : AbstractValidator<UpdateGenreOfBookDto>
    {
        public UpdateGenreOfBookDtoValidator()
        {
            RuleFor(book => book.BookId).InclusiveBetween(1, int.MaxValue);
            RuleFor(genre => genre.OldGenreId).InclusiveBetween(1, int.MaxValue);
            RuleFor(genre => genre.NewGenreId).InclusiveBetween(0, int.MaxValue);
        }
    }
}
