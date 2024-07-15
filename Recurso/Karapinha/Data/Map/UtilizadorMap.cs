using Karapinha.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karapinha.Data.Map
{
    public class UtilizadorMap : IEntityTypeConfiguration<Utilizador>
    {
        public void Configure(EntityTypeBuilder<Utilizador> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Telemovel).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Bi).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Photo).HasColumnType("varbinary(max)");
            builder.Property(x => x.NivelAcesso).IsRequired().HasMaxLength(50); // Novo campo

        }
    }
}
