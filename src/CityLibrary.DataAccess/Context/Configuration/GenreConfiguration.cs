using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.Context.Configuration;

internal sealed class GenreConfiguration : IEntityTypeConfiguration<GenreDb>
{
    public void Configure(EntityTypeBuilder<GenreDb> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id).ValueGeneratedOnAdd();
        builder.Property(g => g.Name).HasMaxLength(200).IsRequired();
    }
}