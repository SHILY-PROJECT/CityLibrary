namespace CityLibrary.WebApi.Models.Genre;

public record GenreStatsDto
{
    public GenreDto Genre { get; init; }
    public int Quantity { get; init; }
}
