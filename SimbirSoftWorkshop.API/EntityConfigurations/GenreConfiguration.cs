using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimbirSoftWorkshop.API.Models.Entity;

namespace SimbirSoftWorkshop.API.EntityConfigurations
{
    /// <summary>
    /// Конфигурирование таблицы жанров.
    /// </summary>
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.GenreName).HasColumnName("genre_name").HasMaxLength(200).IsRequired(true);
        }
    }
}
