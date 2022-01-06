using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinaAPIRest.Migrations
{
    public partial class teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FotoPortifolio");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Portifolio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Portifolio");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FotoPortifolio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
