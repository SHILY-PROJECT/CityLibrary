using FluentValidation;

namespace CityLibrary.WebApi.Models.Genres.Validators;

public class GenreDtoValidator : AbstractValidator<GenreDto>
{
    public GenreDtoValidator()
    {
        RuleFor(g => g.Name).Length(1, 200);
    }
}