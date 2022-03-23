using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.EntityConfigurations;

public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCardDb>
{
    public void Configure(EntityTypeBuilder<LibraryCardDb> builder)
    {
        builder.HasKey(x => x.Id);
    }
}