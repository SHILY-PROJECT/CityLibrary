using FluentValidation;

namespace SimbirSoftWorkshop.API.Models.Dto.Authors.Validators
{
    public class AuthorIdValidator : AbstractValidator<AuthorIdDto>
    {
        public AuthorIdValidator()
        {
            RuleFor(author => author.Id).InclusiveBetween(1, int.MaxValue);
        }
    }
}
