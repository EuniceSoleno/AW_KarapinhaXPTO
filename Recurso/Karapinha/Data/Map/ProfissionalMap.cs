using Karapinha.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Data.Map
{
    public class ProfissionalMap : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.ProfissionalNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.telemovel).IsRequired().HasMaxLength(15);
            builder.Property(x => x.bi).IsRequired().HasMaxLength(20);
            builder.Property(x => x.password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.photo).HasColumnType("varbinary(max)");

            builder.HasOne(x => x.Categoria);
        }
    }
}
