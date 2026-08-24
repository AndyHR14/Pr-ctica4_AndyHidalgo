using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class PokemonID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Usuario");
        }
    }
}
