using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoentidadeparasalvarcurtidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "curtida_postagem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    postagem_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_remocao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curtida_postagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_curtida_postagem_postagem_postagem_id",
                        column: x => x.postagem_id,
                        principalTable: "postagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_curtida_postagem_postagem_id_usuario_id",
                table: "curtida_postagem",
                columns: new[] { "postagem_id", "usuario_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "curtida_postagem");
        }
    }
}
