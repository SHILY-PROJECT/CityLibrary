using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.EntityConfigurations;

internal sealed class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCardDb>
{
    public void Configure(EntityTypeBuilder<LibraryCardDb> builder)
    {
        builder.HasKey(lc => new { lc.PersonId, lc.BookId });

        builder.Property(lc => lc.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(lc => lc.Person)
            .WithOne()
            .HasForeignKey<LibraryCardDb>(lc => lc.PersonId);

        builder
            .HasOne(lc => lc.Book)
            .WithOne()
            .HasForeignKey<LibraryCardDb>(lc => lc.BookId);
    }
}