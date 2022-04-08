using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.EntityConfigurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<PersonDb>
{
    public void Configure(EntityTypeBuilder<PersonDb> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.MiddleName).HasMaxLength(50);
    }
}