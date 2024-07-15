using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class Marcacoes_E_Tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoTabelaDeHorario");

            migrationBuilder.AddColumn<int>(
                name: "TabelaDeHorarioId",
                table: "Marcacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_TabelaDeHorarioId",
                table: "Marcacoes",
                column: "TabelaDeHorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marcacoes_TabelasDeHorarios_TabelaDeHorarioId",
                table: "Marcacoes",
                column: "TabelaDeHorarioId",
                principalTable: "TabelasDeHorarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marcacoes_TabelasDeHorarios_TabelaDeHorarioId",
                table: "Marcacoes");

            migrationBuilder.DropIndex(
                name: "IX_Marcacoes_TabelaDeHorarioId",
                table: "Marcacoes");

            migrationBuilder.DropColumn(
                name: "TabelaDeHorarioId",
                table: "Marcacoes");

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
                name: "IX_MarcacaoTabelaDeHorario_TabelaDeHorariosId",
                table: "MarcacaoTabelaDeHorario",
                column: "TabelaDeHorariosId");
        }
    }
}
