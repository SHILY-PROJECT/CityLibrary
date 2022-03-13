using Microsoft.EntityFrameworkCore;
using DataAccess.EntityConfigurations;
using DataAccess.Entities;

namespace DataAccess;

public class CityLibraryDbContext : DbContext
{
    public CityLibraryDbContext(DbContextOptions<CityLibraryDbContext> options) : base(options)
    {
        if (Database.CanConnect() is false)
        {
            Database.EnsureCreated();
        }
    }

    public DbSet<AuthorDb> Authors { get; set; }
    public DbSet<BookDb> Books { get; set; }
    public DbSet<PersonDb> Persons { get; set; }
    public DbSet<GenreDb> Genres { get; set; }
    public DbSet<LibraryCardDb> LibraryCards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());

        base.OnModelCreating(modelBuilder);
    }

}