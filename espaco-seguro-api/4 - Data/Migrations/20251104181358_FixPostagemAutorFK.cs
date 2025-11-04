using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class FixPostagemAutorFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postagem_usuario_autor_id1",
                table: "postagem");

            migrationBuilder.DropIndex(
                name: "IX_postagem_autor_id1",
                table: "postagem");

            migrationBuilder.DropColumn(
                name: "autor_id1",
                table: "postagem");

            migrationBuilder.CreateIndex(
                name: "IX_postagem_autor_id",
                table: "postagem",
                column: "autor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_postagem_usuario_autor_id",
                table: "postagem",
                column: "autor_id",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postagem_usuario_autor_id",
                table: "postagem");

            migrationBuilder.DropIndex(
                name: "IX_postagem_autor_id",
                table: "postagem");

            migrationBuilder.AddColumn<Guid>(
                name: "autor_id1",
                table: "postagem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_postagem_autor_id1",
                table: "postagem",
                column: "autor_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_postagem_usuario_autor_id1",
                table: "postagem",
                column: "autor_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
