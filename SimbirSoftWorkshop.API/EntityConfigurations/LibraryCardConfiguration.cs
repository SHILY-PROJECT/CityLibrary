using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimbirSoftWorkshop.API.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftWorkshop.API.EntityConfigurations
{
    /// <summary>
    /// Конфигурирование таблицы библиотечных карточек.
    /// </summary>
    public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
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
