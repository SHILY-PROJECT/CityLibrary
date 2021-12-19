using FluentValidation;

namespace SimbirSoftWorkshop.API.Models.Dto.Authors.Validators
{
    public class AuthorShortIdValidator : AbstractValidator<AuthorIdDto>
    {
        public AuthorShortIdValidator()
        {
            RuleFor(author => author.Id).InclusiveBetween(1, int.MaxValue);
        }
    }
}
