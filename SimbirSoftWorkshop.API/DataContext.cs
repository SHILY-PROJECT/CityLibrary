using Microsoft.EntityFrameworkCore;
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
            Database.EnsureCreated();
        }

        /// <summary>
        /// 2.3 - Конфигурировение/мапинг БД (Fluent API)
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(x =>
            {
                x.Property(p => p.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
                x.Property(p => p.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired(true);
                x.Property(p => p.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired(true);
                x.Property(p => p.MiddleName).HasColumnName("middle_name").HasMaxLength(50).IsRequired(false);

                x.HasKey(k => k.Id);
                x.ToTable("author");
            });

            modelBuilder.Entity<Person>(x =>
            {
                x.Property(p => p.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
                x.Property(p => p.BirthDate).HasColumnName("birth_date");
                x.Property(p => p.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired(true);
                x.Property(p => p.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired(true);
                x.Property(p => p.MiddleName).HasColumnName("middle_name").HasMaxLength(50).IsRequired(false);

                x.HasKey(k => k.Id);
                x.ToTable("person");
            });

            modelBuilder.Entity<Genre>(x =>
            {
                x.Property(p => p.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
                x.Property(p => p.GenreName).HasColumnName("genre_name").HasMaxLength(200).IsRequired(true);

                x.HasKey(k => k.Id);
                x.ToTable("genre");
            });

            modelBuilder.Entity<Book>(x =>
            {
                x.Property(p => p.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
                x.Property(p => p.Name).HasColumnName("name").HasMaxLength(500).IsRequired(true);
                x.Property(p => p.AuthorId).HasColumnName("author_id").IsRequired(true);

                x.HasKey(k => k.Id);
                x.HasOne(b => b.Author).WithMany(a => a.Books);
                x.ToTable("book");
            });

            modelBuilder.Entity<BookGenre>(x =>
            {
                x.Property(p => p.BookId).HasColumnName("book_id").IsRequired(true);
                x.Property(p => p.GenreId).HasColumnName("genre_id").IsRequired(true);

                x.HasKey(k => new { k.BookId, k.GenreId }).HasName("PK_book_id_genre_id");
                x.HasOne<Book>(bg => bg.Book)
                    .WithMany(b => b.BooksGenres)
                    .HasForeignKey(bg => bg.BookId)
                    .HasConstraintName("FK_book_genre_book");
                x.HasOne<Genre>(bg => bg.Genre)
                    .WithMany(g => g.BookGenre)
                    .HasForeignKey(bg => bg.GenreId)
                    .HasConstraintName("FK_book_genre_genre");
                x.ToTable("book_genre");
            });

            modelBuilder.Entity<LibraryCard>(x =>
            {
                x.Property(p => p.BookId).HasColumnName("book_id").IsRequired(true);
                x.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(true);

                x.HasKey(k => new { k.BookId, k.PersonId }).HasName("PK_book_id_person_id");
                x.HasOne<Book>(lb => lb.Book)
                    .WithMany(b => b.LibraryCards)
                    .HasForeignKey(lb => lb.BookId)
                    .HasConstraintName("FK_library_card_book");
                x.HasOne<Person>(lb => lb.Person)
                    .WithMany(p => p.LibraryCard)
                    .HasForeignKey(lb => lb.PersonId)
                    .HasConstraintName("FK_library_card_person");
                x.ToTable("library_card");
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}
