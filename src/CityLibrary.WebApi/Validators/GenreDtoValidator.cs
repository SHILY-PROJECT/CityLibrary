using FluentValidation;
using CityLibrary.WebApi.Models;

namespace CityLibrary.WebApi.Validators;

public class GenreDtoValidator : AbstractValidator<GenreDto>
{
    public GenreDtoValidator()
    {
        RuleFor(g => g.Name).Length(1, 200);
    }
}