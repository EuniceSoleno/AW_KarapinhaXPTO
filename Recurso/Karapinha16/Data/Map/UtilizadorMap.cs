using Karapinha.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karapinha.Data.Map
{
    public class UtilizadorMap : IEntityTypeConfiguration<Utilizador>
    {
        public void Configure(EntityTypeBuilder<Utilizador> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.nomeCompleto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.telemovel).IsRequired().HasMaxLength(15);
            builder.Property(x => x.bi).IsRequired().HasMaxLength(20);
            builder.Property(x => x.username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.photo).HasColumnType("varbinary(max)");

            builder.Property(x => x.nivelDeAcesso)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
