using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.Context.Configuration;

internal sealed class BookConfiguration : IEntityTypeConfiguration<BookDb>
{
    public void Configure(EntityTypeBuilder<BookDb> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Name).HasMaxLength(500).IsRequired();
        builder.Property(b => b.AuthorId).IsRequired();

        builder
            .HasOne(b => b.Author)
            .WithMany()
            .HasForeignKey(b => b.AuthorId);

        builder
            .HasOne(b => b.Genre)
            .WithMany()
            .HasForeignKey(b => b.GenreId);
    }
}