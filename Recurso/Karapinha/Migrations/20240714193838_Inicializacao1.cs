using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class Inicializacao1 : Migration
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
                name: "Marcacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaSemana = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Minuto = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcacoes", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "TabelasDeHorarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    HoraFim = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelasDeHorarios", x => x.Id);
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
                name: "MarcacaoCategoria",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    MarcacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoCategoria", x => new { x.CategoriasId, x.MarcacoesId });
                    table.ForeignKey(
                        name: "FK_MarcacaoCategoria_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoCategoria_Marcacoes_MarcacoesId",
                        column: x => x.MarcacoesId,
                        principalTable: "Marcacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarcacaoProfissional",
                columns: table => new
                {
                    MarcacoesId = table.Column<int>(type: "int", nullable: false),
                    Profissionaisid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoProfissional", x => new { x.MarcacoesId, x.Profissionaisid });
                    table.ForeignKey(
                        name: "FK_MarcacaoProfissional_Marcacoes_MarcacoesId",
                        column: x => x.MarcacoesId,
                        principalTable: "Marcacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoProfissional_Profissionais_Profissionaisid",
                        column: x => x.Profissionaisid,
                        principalTable: "Profissionais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarcacaoServico",
                columns: table => new
                {
                    MarcacoesId = table.Column<int>(type: "int", nullable: false),
                    ServicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoServico", x => new { x.MarcacoesId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_MarcacaoServico_Marcacoes_MarcacoesId",
                        column: x => x.MarcacoesId,
                        principalTable: "Marcacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoServico_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarcacaoTabelaDeHorario",
                columns: table => new
                {
                    MarcacoesId = table.Column<int>(type: "int", nullable: false),
                    TabelaDeHorariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoTabelaDeHorario", x => new { x.MarcacoesId, x.TabelaDeHorariosId });
                    table.ForeignKey(
                        name: "FK_MarcacaoTabelaDeHorario_Marcacoes_MarcacoesId",
                        column: x => x.MarcacoesId,
                        principalTable: "Marcacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoTabelaDeHorario_TabelasDeHorarios_TabelaDeHorariosId",
                        column: x => x.TabelaDeHorariosId,
                        principalTable: "TabelasDeHorarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoCategoria_MarcacoesId",
                table: "MarcacaoCategoria",
                column: "MarcacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoProfissional_Profissionaisid",
                table: "MarcacaoProfissional",
                column: "Profissionaisid");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServico_ServicosId",
                table: "MarcacaoServico",
                column: "ServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoTabelaDeHorario_TabelaDeHorariosId",
                table: "MarcacaoTabelaDeHorario",
                column: "TabelaDeHorariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoCategoria");

            migrationBuilder.DropTable(
                name: "MarcacaoProfissional");

            migrationBuilder.DropTable(
                name: "MarcacaoServico");

            migrationBuilder.DropTable(
                name: "MarcacaoTabelaDeHorario");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Marcacoes");

            migrationBuilder.DropTable(
                name: "TabelasDeHorarios");
        }
    }
}
