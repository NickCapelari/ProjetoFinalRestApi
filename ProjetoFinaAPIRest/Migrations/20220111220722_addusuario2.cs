using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinaAPIRest.Migrations
{
    public partial class addusuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Pessoa_PessoaId",
                table: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Contato_PessoaId",
                table: "Usuario",
                newName: "IX_Usuario_PessoaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pessoa_PessoaId",
                table: "Usuario",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa_PessoaId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Contato");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_PessoaId",
                table: "Contato",
                newName: "IX_Contato_PessoaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Pessoa_PessoaId",
                table: "Contato",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
