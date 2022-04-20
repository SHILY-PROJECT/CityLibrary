using FluentValidation;

namespace CityLibrary.Api.Models.Genres.Validators;

public class GenreDtoValidator : AbstractValidator<GenreDto>
{
    public GenreDtoValidator()
    {
        RuleFor(g => g.Name).Length(1, 200);
    }
}