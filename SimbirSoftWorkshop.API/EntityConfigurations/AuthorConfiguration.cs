using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.EntityConfigurations
{
    /// <summary>
    /// Конфигурирование таблицы авторов.
    /// </summary>
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("author").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.MiddleName).HasColumnName("middle_name").HasMaxLength(50).IsRequired(false);
        }
    }
}
