namespace CityLibrary.Domain.Models;

public record GenreStats
{
    public Genre Genre { get; init; }
    public int Quantity { get; init; }
}