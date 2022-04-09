namespace CityLibrary.Domain.Models;

public record Book
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Genre Genre { get; init; }
    public Author Author { get; init; }
}