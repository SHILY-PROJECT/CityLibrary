using FluentValidation;

namespace SimbirSoftWorkshop.API.Models.Dto.Genres.Validators
{
    public class AddGenreValidator : AbstractValidator<AddGenre>
    {
        public AddGenreValidator()
        {
            RuleFor(x => x.Name).Length(1, 200);
        }
    }
}
