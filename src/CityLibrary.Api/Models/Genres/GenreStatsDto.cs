namespace CityLibrary.Api.Models.Genres;

public record GenreStatsDto
{
    public GenreDto Genre { get; init; }
    public int Quantity { get; init; }
}
