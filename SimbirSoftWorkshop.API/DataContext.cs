using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            modelBuilder.Entity<Author>(AuthorConfigure);
            modelBuilder.Entity<Person>(PersonConfigure);
            modelBuilder.Entity<Genre>(GenreConfigure);
            modelBuilder.Entity<Book>(BookConfigure);
            modelBuilder.Entity<BookGenre>(BookGenreConfigure);
            modelBuilder.Entity<LibraryCard>(LibraryCardConfigure);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Конфигурирование таблицы авторов.
        /// </summary>
        public void AuthorConfigure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("author").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.MiddleName).HasColumnName("middle_name").HasMaxLength(50).IsRequired(false);
        }

        /// <summary>
        /// Конфигурирование таблицы пользователей.
        /// </summary>
        public void PersonConfigure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.MiddleName).HasColumnName("middle_name").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.BirthDate).HasColumnName("birth_date");
        }

        /// <summary>
        /// Конфигурирование таблицы жанров.
        /// </summary>
        public void GenreConfigure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.GenreName).HasColumnName("genre_name").HasMaxLength(200).IsRequired(true);
        }

        /// <summary>
        /// Конфигурирование таблицы книг.
        /// </summary>
        public void BookConfigure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book").HasKey(x => x.Id);
            builder.HasOne(x => x.Author).WithMany(x => x.Books);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.AuthorId).HasColumnName("author_id").IsRequired(true);
        }

        /// <summary>
        /// Конфигурирование таблицы книг-жанров.
        /// </summary>
        public void BookGenreConfigure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.ToTable("book_genre");
            builder.HasKey(x => new { x.BookId, x.GenreId }).HasName("PK_book_id_genre_id");

            builder.HasOne<Book>(bg => bg.Book)
                .WithMany(b => b.BooksGenres)
                .HasForeignKey(bg => bg.BookId)
                .HasConstraintName("FK_book_genre_book");

            builder.HasOne<Genre>(bg => bg.Genre)
                .WithMany(g => g.BookGenre)
                .HasForeignKey(bg => bg.GenreId)
                .HasConstraintName("FK_book_genre_genre");

            builder.Property(x => x.BookId).HasColumnName("book_id").IsRequired(true);
            builder.Property(x => x.GenreId).HasColumnName("genre_id").IsRequired(true);
        }

        /// <summary>
        /// Конфигурирование таблицы библиотечных карточек.
        /// </summary>
        public void LibraryCardConfigure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.ToTable("library_card");
            builder.HasKey(x => new { x.BookId, x.PersonId }).HasName("PK_book_id_person_id");

            builder.HasOne<Book>(lb => lb.Book)
                .WithMany(b => b.LibraryCards)
                .HasForeignKey(lb => lb.BookId)
                .HasConstraintName("FK_library_card_book");

            builder.HasOne<Person>(lb => lb.Person)
                .WithMany(p => p.LibraryCard)
                .HasForeignKey(lb => lb.PersonId)
                .HasConstraintName("FK_library_card_person");

            builder.Property(p => p.BookId).HasColumnName("book_id").IsRequired(true);
            builder.Property(p => p.PersonId).HasColumnName("person_id").IsRequired(true);
        }

    }

}
