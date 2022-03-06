using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.WebApi.Models.Entity;

namespace WebApi.EntityConfigurations
{
    /// <summary>
    /// Конфигурирование таблицы книг.
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book").HasKey(x => x.Id);
            builder.HasOne(x => x.Author).WithMany(x => x.Books);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.AuthorId).HasColumnName("author_id").IsRequired(true);
        }
    }
}
