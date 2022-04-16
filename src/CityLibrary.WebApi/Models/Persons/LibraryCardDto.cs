using System;
using CityLibrary.WebApi.Models.Books;

namespace CityLibrary.WebApi.Models.Persons;

public record LibraryCardDto
{
    public Guid Id { get; init; }
    public PersonDto Person { get; init; }
    public BookDto Book { get; init; }
    public DateTime DataReceived { get; init; }
}