using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimbirSoftWorkshop.API.EntityConfigurations;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API
{
    /// <summary>
    /// 2.1 - Класс для подключения к БД
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BooksGenres { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (Database.CanConnect() is false) Database.EnsureCreated();
        }

        /// <summary>
        /// 2.3 - Конфигурировение/мапинг БД (Fluent API)
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookGenreConfiguration());
            modelBuilder.ApplyConfiguration(new LibraryCardConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
