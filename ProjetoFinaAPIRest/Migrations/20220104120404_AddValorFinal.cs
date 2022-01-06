using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinaAPIRest.Migrations
{
    public partial class AddValorFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorFinal",
                table: "Ingresso",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorFinal",
                table: "Ingresso");
        }
    }
}
