using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Entities;

namespace DataAccess.EntityConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<AuthorDb>
{
    public void Configure(EntityTypeBuilder<AuthorDb> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.MiddleName).HasMaxLength(50);
    }
}