using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class eliminadaRedundanciaProfissional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoProfissional");

            migrationBuilder.AddColumn<int>(
                name: "MarcacaoId",
                table: "Profissionais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_bi",
                table: "Profissionais",
                column: "bi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_MarcacaoId",
                table: "Profissionais",
                column: "MarcacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_telemovel",
                table: "Profissionais",
                column: "telemovel",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Marcacoes_MarcacaoId",
                table: "Profissionais",
                column: "MarcacaoId",
                principalTable: "Marcacoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Marcacoes_MarcacaoId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_bi",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_MarcacaoId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_telemovel",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "MarcacaoId",
                table: "Profissionais");

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

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoProfissional_Profissionaisid",
                table: "MarcacaoProfissional",
                column: "Profissionaisid");
        }
    }
}
