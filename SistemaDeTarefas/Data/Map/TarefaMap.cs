﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property( x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property( x => x.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.status).IsRequired();
            builder.Property(x => x.Usuario);

            builder.HasOne(x => x.Usuario);
        }
    }
}
