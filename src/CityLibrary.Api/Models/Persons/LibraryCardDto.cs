using System;
using CityLibrary.Api.Models.Books;

namespace CityLibrary.Api.Models.Persons;

public record LibraryCardDto
{
    public Guid Id { get; init; }
    public PersonDto Person { get; init; }
    public BookDto Book { get; init; }
    public DateTime DataReceived { get; init; }
}