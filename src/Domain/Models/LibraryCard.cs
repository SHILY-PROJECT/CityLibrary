namespace Domain.Models;

public record LibraryCard
{
    public Guid Id { get; init; }
    public Person Person { get; init; }
    public Book Book { get; init; }
    public DateTime DataReceived { get; init; }
}