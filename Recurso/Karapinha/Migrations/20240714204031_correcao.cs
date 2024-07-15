using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoServico");

            migrationBuilder.AddColumn<int>(
                name: "MarcacaoId",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_MarcacaoId",
                table: "Servicos",
                column: "MarcacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Marcacoes_MarcacaoId",
                table: "Servicos",
                column: "MarcacaoId",
                principalTable: "Marcacoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Marcacoes_MarcacaoId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_MarcacaoId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "MarcacaoId",
                table: "Servicos");

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

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServico_ServicosId",
                table: "MarcacaoServico",
                column: "ServicosId");
        }
    }
}
