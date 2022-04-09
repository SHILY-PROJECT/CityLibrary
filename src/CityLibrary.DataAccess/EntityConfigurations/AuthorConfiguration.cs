using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityLibrary.DataAccess.Entities;

namespace CityLibrary.DataAccess.EntityConfigurations;

internal sealed class AuthorConfiguration : IEntityTypeConfiguration<AuthorDb>
{
    public void Configure(EntityTypeBuilder<AuthorDb> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
        builder.Property(a => a.MiddleName).HasMaxLength(50).IsRequired(false);
    }
}