using Karapinha.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Data.Map
{
    public class MarcacaoMap : IEntityTypeConfiguration<Marcacao>
    {
        public void Configure(EntityTypeBuilder<Marcacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CategoriaNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ServicoNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfissionalNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DiaSemana).IsRequired().HasMaxLength(10);
            builder.Property(x => x.hora).IsRequired().HasMaxLength(2);
            builder.Property(x => x.minuto).IsRequired().HasMaxLength(2);

            builder.HasOne(x => x.Categoria);


            builder.HasOne(x => x.Servico);

            builder.HasOne(x => x.Profissional);

        }
    }
}