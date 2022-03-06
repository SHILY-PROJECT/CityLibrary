namespace DataAccess.Entities;

public class Genre
{
    public int Id { get; set; }
    public string GenreName { get; set; }

    public IEnumerable<BookGenre> BookGenre { get; set; }
}

