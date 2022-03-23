using DataAccess.Interfaces;

namespace DataAccess.Entities;

public record GenreDb : IGuidProperty
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}