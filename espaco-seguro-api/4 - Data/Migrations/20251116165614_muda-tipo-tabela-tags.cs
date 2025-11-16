using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class mudatipotabelatags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "tags",
                table: "conteudo_card",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tags",
                table: "conteudo_card",
                type: "jsonb",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string[]),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
