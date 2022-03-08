using DataAccess.Interfaces;

namespace DataAccess.Entities;

public class AuthorDb : IGuidProperty
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}