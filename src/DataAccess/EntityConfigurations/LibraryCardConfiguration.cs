using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Entities;

namespace DataAccess.EntityConfigurations;

public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCardDb>
{
    public void Configure(EntityTypeBuilder<LibraryCardDb> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
