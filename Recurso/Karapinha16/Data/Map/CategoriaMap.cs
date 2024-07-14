using Karapinha.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoriaNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(500);
        }
    }
}
