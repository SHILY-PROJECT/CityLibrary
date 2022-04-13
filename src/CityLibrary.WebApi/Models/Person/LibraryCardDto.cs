using CityLibrary.WebApi.Models.Book;
using System;

namespace CityLibrary.WebApi.Models.Person;

public record LibraryCardDto
{
    public Guid Id { get; init; }
    public PersonDto Person { get; init; }
    public BookDto Book { get; init; }
    public DateTime DataReceived { get; init; }
}