namespace CityLibrary.DataAccess.Entities;

public record LibraryCardDb
{
    public Guid Id { get; set; }
    public DateTime DataReceived { get; set; }

    public Guid PersonId { get; set; }
    public PersonDb Person { get; set; }

    public Guid BookId { get; set; }
    public BookDb Book { get; set; }
}