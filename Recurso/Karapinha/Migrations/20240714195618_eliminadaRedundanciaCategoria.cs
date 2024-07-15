using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class eliminadaRedundanciaCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoCategoria");

            migrationBuilder.AddColumn<int>(
                name: "MarcacaoId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_MarcacaoId",
                table: "Categorias",
                column: "MarcacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Marcacoes_MarcacaoId",
                table: "Categorias",
                column: "MarcacaoId",
                principalTable: "Marcacoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Marcacoes_MarcacaoId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_MarcacaoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "MarcacaoId",
                table: "Categorias");

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

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoCategoria_MarcacoesId",
                table: "MarcacaoCategoria",
                column: "MarcacoesId");
        }
    }
}
