using FluentValidation;

namespace SimbirSoftWorkshop.API.Models.Dto.Authors.Validators
{
    public class AuthorDtoValidator : AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator()
        {
            RuleFor(author => author.FirstName).Length(2, 50);
            RuleFor(author => author.LastName).Length(2, 50);
            RuleFor(author => author.MiddleName).NotNull().Length(0, 50);
        }
    }
}
