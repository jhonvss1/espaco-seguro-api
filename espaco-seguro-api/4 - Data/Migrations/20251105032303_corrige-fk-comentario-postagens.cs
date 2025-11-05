using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class corrigefkcomentariopostagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentario_postagem_postagem_postagem_id1",
                table: "comentario_postagem");

            migrationBuilder.DropForeignKey(
                name: "FK_comentario_postagem_usuario_autor_id1",
                table: "comentario_postagem");

            migrationBuilder.DropIndex(
                name: "IX_comentario_postagem_autor_id1",
                table: "comentario_postagem");

            migrationBuilder.DropIndex(
                name: "IX_comentario_postagem_postagem_id1",
                table: "comentario_postagem");

            migrationBuilder.DropColumn(
                name: "autor_id1",
                table: "comentario_postagem");

            migrationBuilder.DropColumn(
                name: "postagem_id1",
                table: "comentario_postagem");

            migrationBuilder.CreateIndex(
                name: "IX_comentario_postagem_autor_id",
                table: "comentario_postagem",
                column: "autor_id");

            migrationBuilder.CreateIndex(
                name: "IX_comentario_postagem_postagem_id",
                table: "comentario_postagem",
                column: "postagem_id");

            migrationBuilder.AddForeignKey(
                name: "FK_comentario_postagem_postagem_postagem_id",
                table: "comentario_postagem",
                column: "postagem_id",
                principalTable: "postagem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentario_postagem_usuario_autor_id",
                table: "comentario_postagem",
                column: "autor_id",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentario_postagem_postagem_postagem_id",
                table: "comentario_postagem");

            migrationBuilder.DropForeignKey(
                name: "FK_comentario_postagem_usuario_autor_id",
                table: "comentario_postagem");

            migrationBuilder.DropIndex(
                name: "IX_comentario_postagem_autor_id",
                table: "comentario_postagem");

            migrationBuilder.DropIndex(
                name: "IX_comentario_postagem_postagem_id",
                table: "comentario_postagem");

            migrationBuilder.AddColumn<Guid>(
                name: "autor_id1",
                table: "comentario_postagem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "postagem_id1",
                table: "comentario_postagem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_comentario_postagem_autor_id1",
                table: "comentario_postagem",
                column: "autor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_comentario_postagem_postagem_id1",
                table: "comentario_postagem",
                column: "postagem_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_comentario_postagem_postagem_postagem_id1",
                table: "comentario_postagem",
                column: "postagem_id1",
                principalTable: "postagem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comentario_postagem_usuario_autor_id1",
                table: "comentario_postagem",
                column: "autor_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
