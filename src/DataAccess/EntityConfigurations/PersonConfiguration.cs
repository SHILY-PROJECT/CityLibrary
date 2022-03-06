using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.WebApi.Models.Entity;

namespace WebApi.EntityConfigurations
{
    /// <summary>
    /// Конфигурирование таблицы пользователей.
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn(1, 1).IsRequired(true);
            builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.MiddleName).HasColumnName("middle_name").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.BirthDate).HasColumnName("birth_date");
        }
    }
}
