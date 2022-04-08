namespace CityLibrary.DataAccess.Entities;

public record LibraryCardDb
{
    public Guid Id { get; init; }
    public DateTime DateBookReceived { get; init; }

    public Guid PersonId { get; init; }
    public PersonDb Person { get; init; }

    public Guid BookId { get; init; }
    public BookDb Book { get; init; }
}