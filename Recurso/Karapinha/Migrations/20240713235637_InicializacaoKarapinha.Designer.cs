﻿// <auto-generated />
using System;
using Karapinha.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Karapinha.Migrations
{
    [DbContext(typeof(KarapinhaDBContext))]
    [Migration("20240713235637_InicializacaoKarapinha")]
    partial class InicializacaoKarapinha
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Karapinha.Model.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Karapinha.Model.Marcacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ProfissionalNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Profissionalid")
                        .HasColumnType("int");

                    b.Property<int?>("ServicoId")
                        .HasColumnType("int");

                    b.Property<string>("ServicoNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("hora")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("minuto")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("Profissionalid");

                    b.HasIndex("ServicoId");

                    b.ToTable("Marcacoes");
                });

            modelBuilder.Entity("Karapinha.Model.Profissional", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("ProfissionalNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("bi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("telemovel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Profissionais");
                });

            modelBuilder.Entity("Karapinha.Model.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("ServicoNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Karapinha.Model.TabelaDeHorario", b =>
                {
                    b.Property<string>("ProfissionalNome")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("hora")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("minuto")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("Profissionalid")
                        .HasColumnType("int");

                    b.HasKey("ProfissionalNome", "hora", "minuto");

                    b.HasIndex("Profissionalid");

                    b.ToTable("TabelaDeHorario");
                });

            modelBuilder.Entity("Karapinha.Model.Utilizador", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("bi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("nomeCompleto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("telemovel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("Karapinha.Model.Marcacao", b =>
                {
                    b.HasOne("Karapinha.Model.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Karapinha.Model.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("Profissionalid");

                    b.HasOne("Karapinha.Model.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId");

                    b.Navigation("Categoria");

                    b.Navigation("Profissional");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Karapinha.Model.Profissional", b =>
                {
                    b.HasOne("Karapinha.Model.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Karapinha.Model.Servico", b =>
                {
                    b.HasOne("Karapinha.Model.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Karapinha.Model.TabelaDeHorario", b =>
                {
                    b.HasOne("Karapinha.Model.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("Profissionalid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissional");
                });
#pragma warning restore 612, 618
        }
    }
}
