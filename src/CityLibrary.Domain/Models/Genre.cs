namespace CityLibrary.Domain.Models;

public record Genre
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}