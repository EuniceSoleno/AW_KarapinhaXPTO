using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class CorrecaoProfissional2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_CategoriaId",
                table: "Profissionais",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Categorias_CategoriaId",
                table: "Profissionais",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Categorias_CategoriaId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_CategoriaId",
                table: "Profissionais");
        }
    }
}
