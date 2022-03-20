namespace Domain.Models;

public class LibraryCard
{
    public Guid Id { get; set; }
    public Person Person { get; set; }
    public Book Book { get; set; }
    public DateTime DataReceived { get; set; }
}