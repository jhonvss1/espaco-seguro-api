using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class migrationtwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentario_postagem_Usuarios_autor_id1",
                table: "comentario_postagem");

            migrationBuilder.DropForeignKey(
                name: "FK_conteudo_card_Usuarios_autor_id1",
                table: "conteudo_card");

            migrationBuilder.DropForeignKey(
                name: "FK_medico_Usuarios_usuario_id1",
                table: "medico");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagem_chat_Usuarios_remetente_id1",
                table: "mensagem_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_postagem_Usuarios_autor_id1",
                table: "postagem");

            migrationBuilder.DropForeignKey(
                name: "FK_sessao_chat_Usuarios_usuario_id1",
                table: "sessao_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_verificacao_card_Usuarios_medico_id",
                table: "verificacao_card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuario");

            migrationBuilder.RenameColumn(
                name: "UltimoAcesso",
                table: "usuario",
                newName: "ultimo_acesso");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "usuario",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_comentario_postagem_usuario_autor_id1",
                table: "comentario_postagem",
                column: "autor_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conteudo_card_usuario_autor_id1",
                table: "conteudo_card",
                column: "autor_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medico_usuario_usuario_id1",
                table: "medico",
                column: "usuario_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mensagem_chat_usuario_remetente_id1",
                table: "mensagem_chat",
                column: "remetente_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_postagem_usuario_autor_id1",
                table: "postagem",
                column: "autor_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessao_chat_usuario_usuario_id1",
                table: "sessao_chat",
                column: "usuario_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_verificacao_card_usuario_medico_id",
                table: "verificacao_card",
                column: "medico_id",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comentario_postagem_usuario_autor_id1",
                table: "comentario_postagem");

            migrationBuilder.DropForeignKey(
                name: "FK_conteudo_card_usuario_autor_id1",
                table: "conteudo_card");

            migrationBuilder.DropForeignKey(
                name: "FK_medico_usuario_usuario_id1",
                table: "medico");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagem_chat_usuario_remetente_id1",
                table: "mensagem_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_postagem_usuario_autor_id1",
                table: "postagem");

            migrationBuilder.DropForeignKey(
                name: "FK_sessao_chat_usuario_usuario_id1",
                table: "sessao_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_verificacao_card_usuario_medico_id",
                table: "verificacao_card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "ultimo_acesso",
                table: "Usuarios",
                newName: "UltimoAcesso");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "Usuarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_comentario_postagem_Usuarios_autor_id1",
                table: "comentario_postagem",
                column: "autor_id1",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conteudo_card_Usuarios_autor_id1",
                table: "conteudo_card",
                column: "autor_id1",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medico_Usuarios_usuario_id1",
                table: "medico",
                column: "usuario_id1",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mensagem_chat_Usuarios_remetente_id1",
                table: "mensagem_chat",
                column: "remetente_id1",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_postagem_Usuarios_autor_id1",
                table: "postagem",
                column: "autor_id1",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessao_chat_Usuarios_usuario_id1",
                table: "sessao_chat",
                column: "usuario_id1",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_verificacao_card_Usuarios_medico_id",
                table: "verificacao_card",
                column: "medico_id",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
