using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinaAPIRest.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_LocalEvento_LocalEventoId",
                table: "Evento");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_LocalEvento_LocalEventoId",
                table: "Evento",
                column: "LocalEventoId",
                principalTable: "LocalEvento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_LocalEvento_LocalEventoId",
                table: "Evento");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_LocalEvento_LocalEventoId",
                table: "Evento",
                column: "LocalEventoId",
                principalTable: "LocalEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
