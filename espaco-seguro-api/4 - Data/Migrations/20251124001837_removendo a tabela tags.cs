using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class removendoatabelatags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tags",
                table: "conteudo_card");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "tags",
                table: "conteudo_card",
                type: "text[]",
                nullable: true);
        }
    }
}
