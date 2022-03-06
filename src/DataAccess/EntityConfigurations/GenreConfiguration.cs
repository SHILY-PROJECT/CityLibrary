using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Entities;

namespace DataAccess.EntityConfigurations;

public class GenreConfiguration : IEntityTypeConfiguration<GenreDb>
{
    public void Configure(EntityTypeBuilder<GenreDb> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
    }
}
