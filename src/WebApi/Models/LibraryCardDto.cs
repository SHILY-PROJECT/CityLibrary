using System;

namespace WebApi.Models;

public class LibraryCardDto
{
    public Guid Id { get; set; }
    public PersonDto Person { get; set; }
    public BookDto Book { get; set; }
    public DateTime DataReceived { get; set; }
}