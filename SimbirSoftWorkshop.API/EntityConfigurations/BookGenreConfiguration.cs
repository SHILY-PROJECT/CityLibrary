using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.EntityConfigurations
{
    /// <summary>
    /// Конфигурирование таблицы книг-жанров.
    /// </summary>
    public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
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
    }
}
