using Microsoft.EntityFrameworkCore;
using CityLibrary.DataAccess.EntityConfigurations;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess;

public class CityLibraryDbContext : DbContext
{
    public CityLibraryDbContext(DbContextOptions<CityLibraryDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<AuthorDb> Authors { get; set; } = null!;
    public DbSet<BookDb> Books { get; set; } = null!;
    public DbSet<PersonDb> Persons { get; set; } = null!;
    public DbSet<GenreDb> Genres { get; set; } = null!;
    public DbSet<LibraryCardDb> LibraryCards { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new AuthorConfiguration())
            .ApplyConfiguration(new PersonConfiguration())
            .ApplyConfiguration(new GenreConfiguration())
            .ApplyConfiguration(new BookConfiguration())
            .ApplyConfiguration(new LibraryCardConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}