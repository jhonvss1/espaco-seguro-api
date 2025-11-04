using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class ajustatipodatags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Simplesmente apaga a coluna e recria
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "postagem");

            migrationBuilder.AddColumn<string[]>(
                name: "tags",
                table: "postagem",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "postagem");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "postagem",
                type: "jsonb",
                nullable: true);
        }
    }
}
