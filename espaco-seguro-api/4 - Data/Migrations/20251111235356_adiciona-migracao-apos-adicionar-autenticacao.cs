using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class adicionamigracaoaposadicionarautenticacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "funcao",
                table: "usuario",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "funcao",
                table: "usuario",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}
