using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class UsuariosYFKUserStory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsignadoA",
                table: "UserStory");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "UserStory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_UsuarioId",
                table: "UserStory",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStory_Usuario_UsuarioId",
                table: "UserStory",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStory_Usuario_UsuarioId",
                table: "UserStory");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_UserStory_UsuarioId",
                table: "UserStory");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UserStory");

            migrationBuilder.AddColumn<string>(
                name: "AsignadoA",
                table: "UserStory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
