using FluentValidation;

namespace SimbirSoftWorkshop.API.Models.Dto.Authors.Validators
{
    public class AuthorNewBookDtoValidator : AbstractValidator<AuthorNewBookDto>
    {
        public AuthorNewBookDtoValidator()
        {
            RuleFor(book => book.BookName).Length(1, 500);
        }
    }
}
