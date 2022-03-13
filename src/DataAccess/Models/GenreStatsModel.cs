using DataAccess.Entities;

namespace DataAccess.Models;

public class GenreStatsModel
{
    public GenreDb Genre { get; set; }
    public int Quantity { get; set; }
}