using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.Migrations
{
    public partial class revisaoDaTabelaHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFim",
                table: "TabelasDeHorarios");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "TabelasDeHorarios");

            migrationBuilder.AlterColumn<string>(
                name: "ProfissionalNome",
                table: "TabelasDeHorarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DiaSemana",
                table: "TabelasDeHorarios",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "HoraFimHora",
                table: "TabelasDeHorarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraFimMinuto",
                table: "TabelasDeHorarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicioHora",
                table: "TabelasDeHorarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicioMinuto",
                table: "TabelasDeHorarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFimHora",
                table: "TabelasDeHorarios");

            migrationBuilder.DropColumn(
                name: "HoraFimMinuto",
                table: "TabelasDeHorarios");

            migrationBuilder.DropColumn(
                name: "HoraInicioHora",
                table: "TabelasDeHorarios");

            migrationBuilder.DropColumn(
                name: "HoraInicioMinuto",
                table: "TabelasDeHorarios");

            migrationBuilder.AlterColumn<string>(
                name: "ProfissionalNome",
                table: "TabelasDeHorarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DiaSemana",
                table: "TabelasDeHorarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "HoraFim",
                table: "TabelasDeHorarios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HoraInicio",
                table: "TabelasDeHorarios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
