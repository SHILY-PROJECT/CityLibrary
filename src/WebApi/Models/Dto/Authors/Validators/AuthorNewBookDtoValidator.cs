using FluentValidation;

namespace WebApi.WebApi.Models.Dto.Authors.Validators
{
    public class AuthorNewBookDtoValidator : AbstractValidator<AuthorNewBookDto>
    {
        public AuthorNewBookDtoValidator()
        {
            RuleFor(book => book.BookName).Length(1, 500);
        }
    }
}
