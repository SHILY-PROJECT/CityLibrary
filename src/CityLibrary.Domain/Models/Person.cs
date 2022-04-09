namespace CityLibrary.Domain.Models;

public record Person
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    public string Email { get; init; }
    public DateTime BirthDate { get; init; }
}