using Karapinha.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karapinha.Data.Map
{
    public class TabelaDeHorarioMap : IEntityTypeConfiguration<TabelaDeHorario>
    {
        public void Configure(EntityTypeBuilder<TabelaDeHorario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProfissionalNome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.HoraInicioHora)
                .IsRequired();

            builder.Property(x => x.HoraInicioMinuto)
                .IsRequired();

            builder.Property(x => x.HoraFimHora)
                .IsRequired();

            builder.Property(x => x.HoraFimMinuto)
                .IsRequired();

            builder.Property(x => x.DiaSemana)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
