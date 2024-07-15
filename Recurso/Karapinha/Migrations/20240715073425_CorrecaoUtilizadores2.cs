using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class CorrecaoUtilizadores2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Utilizadores",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "telemovel",
                table: "Utilizadores",
                newName: "Telemovel");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "Utilizadores",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Utilizadores",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nomeCompleto",
                table: "Utilizadores",
                newName: "NomeCompleto");

            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "Utilizadores",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "bi",
                table: "Utilizadores",
                newName: "Bi");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Utilizadores",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "NivelAcesso",
                table: "Utilizadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelAcesso",
                table: "Utilizadores");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Utilizadores",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Telemovel",
                table: "Utilizadores",
                newName: "telemovel");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Utilizadores",
                newName: "photo");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Utilizadores",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Utilizadores",
                newName: "nomeCompleto");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Utilizadores",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "Bi",
                table: "Utilizadores",
                newName: "bi");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Utilizadores",
                newName: "id");
        }
    }
}
