using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class InicializacaoKarapinha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCompleto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telemovel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    bi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalNome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telemovel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    bi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.id);
                    table.ForeignKey(
                        name: "FK_Profissionais_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicoNome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelaDeHorario",
                columns: table => new
                {
                    ProfissionalNome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    hora = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    minuto = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Profissionalid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaDeHorario", x => new { x.ProfissionalNome, x.hora, x.minuto });
                    table.ForeignKey(
                        name: "FK_TabelaDeHorario_Profissionais_Profissionalid",
                        column: x => x.Profissionalid,
                        principalTable: "Profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marcacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    ServicoNome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: true),
                    ProfissionalNome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Profissionalid = table.Column<int>(type: "int", nullable: true),
                    DiaSemana = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    hora = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    minuto = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marcacoes_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Marcacoes_Profissionais_Profissionalid",
                        column: x => x.Profissionalid,
                        principalTable: "Profissionais",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Marcacoes_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_CategoriaId",
                table: "Marcacoes",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_Profissionalid",
                table: "Marcacoes",
                column: "Profissionalid");

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_ServicoId",
                table: "Marcacoes",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_CategoriaId",
                table: "Profissionais",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaDeHorario_Profissionalid",
                table: "TabelaDeHorario",
                column: "Profissionalid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marcacoes");

            migrationBuilder.DropTable(
                name: "TabelaDeHorario");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
