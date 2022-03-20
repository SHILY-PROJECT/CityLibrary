using System;

namespace WebApi.Models;

public class PersonDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}