using Karapinha.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karapinha.Data.Map
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ServicoNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Preco).IsRequired().HasColumnType("float");

            builder.HasOne(x => x.Categoria);
        }
    }
}
