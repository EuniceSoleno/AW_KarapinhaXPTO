using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class Alteracao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaDeHorario_Profissionais_ProfissionalCategoriaId",
                table: "TabelaDeHorario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais");

            migrationBuilder.RenameColumn(
                name: "ProfissionalCategoriaId",
                table: "TabelaDeHorario",
                newName: "Profissionalid");

            migrationBuilder.RenameIndex(
                name: "IX_TabelaDeHorario_ProfissionalCategoriaId",
                table: "TabelaDeHorario",
                newName: "IX_TabelaDeHorario_Profissionalid");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Servicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Profissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Profissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaDeHorario_Profissionais_Profissionalid",
                table: "TabelaDeHorario",
                column: "Profissionalid",
                principalTable: "Profissionais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaDeHorario_Profissionais_Profissionalid",
                table: "TabelaDeHorario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais");

            migrationBuilder.RenameColumn(
                name: "Profissionalid",
                table: "TabelaDeHorario",
                newName: "ProfissionalCategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_TabelaDeHorario_Profissionalid",
                table: "TabelaDeHorario",
                newName: "IX_TabelaDeHorario_ProfissionalCategoriaId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Servicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Profissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Profissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos",
                column: "CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaDeHorario_Profissionais_ProfissionalCategoriaId",
                table: "TabelaDeHorario",
                column: "ProfissionalCategoriaId",
                principalTable: "Profissionais",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
