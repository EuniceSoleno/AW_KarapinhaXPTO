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

            builder.Property(x => x.Data)
                .IsRequired();

            builder.Property(x => x.HoraInicio)
                .IsRequired()
                .HasMaxLength(5); // Assuming time format "HH:mm"

            builder.Property(x => x.HoraFim)
                .IsRequired()
                .HasMaxLength(5); // Assuming time format "HH:mm
        }
    }
}
