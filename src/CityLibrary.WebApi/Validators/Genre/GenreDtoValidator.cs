using FluentValidation;
using CityLibrary.WebApi.Models.Genre;

namespace CityLibrary.WebApi.Validators.Genre;

public class GenreDtoValidator : AbstractValidator<GenreDto>
{
    public GenreDtoValidator()
    {
        RuleFor(g => g.Name).Length(1, 200);
    }
}