using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class AlteracaoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marcacoes_Categorias_CategoriaId",
                table: "Marcacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Marcacoes_Profissionais_Profissionalid",
                table: "Marcacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Marcacoes_Servicos_ServicoId",
                table: "Marcacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Categorias_CategoriaId",
                table: "Profissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Categorias_CategoriaId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaDeHorario_Profissionais_Profissionalid",
                table: "TabelaDeHorario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_CategoriaId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Marcacoes_CategoriaId",
                table: "Marcacoes");

            migrationBuilder.DropIndex(
                name: "IX_Marcacoes_Profissionalid",
                table: "Marcacoes");

            migrationBuilder.DropIndex(
                name: "IX_Marcacoes_ServicoId",
                table: "Marcacoes");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Marcacoes");

            migrationBuilder.DropColumn(
                name: "Profissionalid",
                table: "Marcacoes");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Marcacoes");

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

            migrationBuilder.AlterColumn<string>(
                name: "ServicoNome",
                table: "Marcacoes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ProfissionalNome",
                table: "Marcacoes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNome",
                table: "Marcacoes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ServicoNome",
                table: "Marcacoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ProfissionalNome",
                table: "Marcacoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNome",
                table: "Marcacoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Marcacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Profissionalid",
                table: "Marcacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Marcacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicos",
                table: "Servicos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissionais",
                table: "Profissionais",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_CategoriaId",
                table: "Profissionais",
                column: "CategoriaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Marcacoes_Categorias_CategoriaId",
                table: "Marcacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Marcacoes_Profissionais_Profissionalid",
                table: "Marcacoes",
                column: "Profissionalid",
                principalTable: "Profissionais",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Marcacoes_Servicos_ServicoId",
                table: "Marcacoes",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Categorias_CategoriaId",
                table: "Profissionais",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Categorias_CategoriaId",
                table: "Servicos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaDeHorario_Profissionais_Profissionalid",
                table: "TabelaDeHorario",
                column: "Profissionalid",
                principalTable: "Profissionais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
