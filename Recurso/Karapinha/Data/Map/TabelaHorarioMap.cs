using Karapinha.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karapinha.Data.Map
{
    public class TabelaHorarioMap : IEntityTypeConfiguration<TabelaDeHorario>
    {
        public void Configure(EntityTypeBuilder<TabelaDeHorario> builder)
        {
            builder.HasKey(x => new { x.ProfissionalNome, x.hora, x.minuto });

            builder.Property(x => x.hora).IsRequired().HasMaxLength(2);
            builder.Property(x => x.minuto).IsRequired().HasMaxLength(2);

            builder.HasOne(x => x.Profissional);
        }
    }
}
