using Karapinha.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karapinha.Data.Map
{
    public class MarcacaoMap : IEntityTypeConfiguration<Marcacao>
    {
        public void Configure(EntityTypeBuilder<Marcacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DiaSemana).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Hora).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Minuto).IsRequired().HasMaxLength(2);
        }
    }
}
