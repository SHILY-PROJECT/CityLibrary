using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.EntityConfiguration;

internal sealed class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCardDb>
{
    public void Configure(EntityTypeBuilder<LibraryCardDb> builder)
    {
        builder.HasKey(lc => new { lc.PersonId, lc.BookId });

        builder.Property(lc => lc.Id).ValueGeneratedOnAdd();
        builder.Property(lc => lc.DateBookReceived).IsRequired();
        builder.Property(lc => lc.BookId).IsRequired();
        builder.Property(lc => lc.PersonId).IsRequired();

        builder
            .HasOne(lc => lc.Person)
            .WithMany()
            .HasForeignKey(lc => lc.PersonId);

        builder
            .HasOne(lc => lc.Book)
            .WithOne()
            .HasForeignKey<LibraryCardDb>(lc => lc.BookId);
    }
}