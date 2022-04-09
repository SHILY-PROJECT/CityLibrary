using Microsoft.EntityFrameworkCore;
using CityLibrary.DataAccess.Models;
using CityLibrary.DataAccess.Entities;
using CityLibrary.DataAccess.EntityConfigurations;

namespace CityLibrary.DataAccess;

public class CityLibraryDbContext : DbContext
{
    private static bool _isDeletedDatabaseAtFirstStartup;
    private readonly DatabaseCreationSettings _databaseCreationSettings;

    public CityLibraryDbContext(DbContextOptions<CityLibraryDbContext> options, DatabaseCreationSettings databaseCreationSettings) : base(options)
    {
        _databaseCreationSettings = databaseCreationSettings;

        if (databaseCreationSettings.ReCreateDatabaseAtFirstStartup && !_isDeletedDatabaseAtFirstStartup)
        {
            Database.EnsureDeleted();
            _isDeletedDatabaseAtFirstStartup = true;
        }

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

        if (_databaseCreationSettings.AddTestDataWhenCreatingDatabase)
        {
            modelBuilder.ApplyTestData();
        }

        base.OnModelCreating(modelBuilder);
    }
}