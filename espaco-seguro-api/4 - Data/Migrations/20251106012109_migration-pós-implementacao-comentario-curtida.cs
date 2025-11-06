using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class migrationpósimplementacaocomentariocurtida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_certificacao_medico_medico_medico_id1",
                table: "certificacao_medico");

            migrationBuilder.DropForeignKey(
                name: "FK_conteudo_card_usuario_autor_id1",
                table: "conteudo_card");

            migrationBuilder.DropForeignKey(
                name: "FK_fonte_card_conteudo_card_cartao_id1",
                table: "fonte_card");

            migrationBuilder.DropForeignKey(
                name: "FK_medico_usuario_usuario_id1",
                table: "medico");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagem_chat_sessao_chat_sessao_id1",
                table: "mensagem_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagem_chat_usuario_remetente_id1",
                table: "mensagem_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_sessao_chat_usuario_usuario_id1",
                table: "sessao_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_verificacao_card_conteudo_card_cartao_id1",
                table: "verificacao_card");

            migrationBuilder.DropForeignKey(
                name: "FK_verificacao_card_usuario_medico_id",
                table: "verificacao_card");

            migrationBuilder.DropIndex(
                name: "IX_verificacao_card_cartao_id1",
                table: "verificacao_card");

            migrationBuilder.DropIndex(
                name: "IX_verificacao_card_medico_id",
                table: "verificacao_card");

            migrationBuilder.DropIndex(
                name: "IX_sessao_chat_usuario_id1",
                table: "sessao_chat");

            migrationBuilder.DropIndex(
                name: "IX_mensagem_chat_remetente_id1",
                table: "mensagem_chat");

            migrationBuilder.DropIndex(
                name: "IX_mensagem_chat_sessao_id1",
                table: "mensagem_chat");

            migrationBuilder.DropIndex(
                name: "IX_medico_usuario_id1",
                table: "medico");

            migrationBuilder.DropIndex(
                name: "IX_fonte_card_cartao_id1",
                table: "fonte_card");

            migrationBuilder.DropIndex(
                name: "IX_conteudo_card_autor_id1",
                table: "conteudo_card");

            migrationBuilder.DropIndex(
                name: "IX_certificacao_medico_medico_id1",
                table: "certificacao_medico");

            migrationBuilder.DropColumn(
                name: "cartao_id1",
                table: "verificacao_card");

            migrationBuilder.DropColumn(
                name: "medico_id",
                table: "verificacao_card");

            migrationBuilder.DropColumn(
                name: "usuario_id1",
                table: "sessao_chat");

            migrationBuilder.DropColumn(
                name: "remetente_id1",
                table: "mensagem_chat");

            migrationBuilder.DropColumn(
                name: "sessao_id1",
                table: "mensagem_chat");

            migrationBuilder.DropColumn(
                name: "usuario_id1",
                table: "medico");

            migrationBuilder.DropColumn(
                name: "cartao_id1",
                table: "fonte_card");

            migrationBuilder.DropColumn(
                name: "autor_id1",
                table: "conteudo_card");

            migrationBuilder.DropColumn(
                name: "medico_id1",
                table: "certificacao_medico");

            migrationBuilder.CreateIndex(
                name: "IX_verificacao_card_cartao_id",
                table: "verificacao_card",
                column: "cartao_id");

            migrationBuilder.CreateIndex(
                name: "IX_verificacao_card_curador_id",
                table: "verificacao_card",
                column: "curador_id");

            migrationBuilder.CreateIndex(
                name: "IX_sessao_chat_usuario_id",
                table: "sessao_chat",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_chat_remetente_id",
                table: "mensagem_chat",
                column: "remetente_id");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_chat_sessao_id",
                table: "mensagem_chat",
                column: "sessao_id");

            migrationBuilder.CreateIndex(
                name: "IX_medico_usuario_id",
                table: "medico",
                column: "usuario_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fonte_card_cartao_id",
                table: "fonte_card",
                column: "cartao_id");

            migrationBuilder.CreateIndex(
                name: "IX_conteudo_card_autor_id",
                table: "conteudo_card",
                column: "autor_id");

            migrationBuilder.CreateIndex(
                name: "IX_certificacao_medico_medico_id",
                table: "certificacao_medico",
                column: "medico_id");

            migrationBuilder.AddForeignKey(
                name: "FK_certificacao_medico_medico_medico_id",
                table: "certificacao_medico",
                column: "medico_id",
                principalTable: "medico",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conteudo_card_usuario_autor_id",
                table: "conteudo_card",
                column: "autor_id",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fonte_card_conteudo_card_cartao_id",
                table: "fonte_card",
                column: "cartao_id",
                principalTable: "conteudo_card",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medico_usuario_usuario_id",
                table: "medico",
                column: "usuario_id",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mensagem_chat_sessao_chat_sessao_id",
                table: "mensagem_chat",
                column: "sessao_id",
                principalTable: "sessao_chat",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mensagem_chat_usuario_remetente_id",
                table: "mensagem_chat",
                column: "remetente_id",
                principalTable: "usuario",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_sessao_chat_usuario_usuario_id",
                table: "sessao_chat",
                column: "usuario_id",
                principalTable: "usuario",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_verificacao_card_conteudo_card_cartao_id",
                table: "verificacao_card",
                column: "cartao_id",
                principalTable: "conteudo_card",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_verificacao_card_usuario_curador_id",
                table: "verificacao_card",
                column: "curador_id",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_certificacao_medico_medico_medico_id",
                table: "certificacao_medico");

            migrationBuilder.DropForeignKey(
                name: "FK_conteudo_card_usuario_autor_id",
                table: "conteudo_card");

            migrationBuilder.DropForeignKey(
                name: "FK_fonte_card_conteudo_card_cartao_id",
                table: "fonte_card");

            migrationBuilder.DropForeignKey(
                name: "FK_medico_usuario_usuario_id",
                table: "medico");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagem_chat_sessao_chat_sessao_id",
                table: "mensagem_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagem_chat_usuario_remetente_id",
                table: "mensagem_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_sessao_chat_usuario_usuario_id",
                table: "sessao_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_verificacao_card_conteudo_card_cartao_id",
                table: "verificacao_card");

            migrationBuilder.DropForeignKey(
                name: "FK_verificacao_card_usuario_curador_id",
                table: "verificacao_card");

            migrationBuilder.DropIndex(
                name: "IX_verificacao_card_cartao_id",
                table: "verificacao_card");

            migrationBuilder.DropIndex(
                name: "IX_verificacao_card_curador_id",
                table: "verificacao_card");

            migrationBuilder.DropIndex(
                name: "IX_sessao_chat_usuario_id",
                table: "sessao_chat");

            migrationBuilder.DropIndex(
                name: "IX_mensagem_chat_remetente_id",
                table: "mensagem_chat");

            migrationBuilder.DropIndex(
                name: "IX_mensagem_chat_sessao_id",
                table: "mensagem_chat");

            migrationBuilder.DropIndex(
                name: "IX_medico_usuario_id",
                table: "medico");

            migrationBuilder.DropIndex(
                name: "IX_fonte_card_cartao_id",
                table: "fonte_card");

            migrationBuilder.DropIndex(
                name: "IX_conteudo_card_autor_id",
                table: "conteudo_card");

            migrationBuilder.DropIndex(
                name: "IX_certificacao_medico_medico_id",
                table: "certificacao_medico");

            migrationBuilder.AddColumn<Guid>(
                name: "cartao_id1",
                table: "verificacao_card",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "medico_id",
                table: "verificacao_card",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "usuario_id1",
                table: "sessao_chat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "remetente_id1",
                table: "mensagem_chat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "sessao_id1",
                table: "mensagem_chat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "usuario_id1",
                table: "medico",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "cartao_id1",
                table: "fonte_card",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "autor_id1",
                table: "conteudo_card",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "medico_id1",
                table: "certificacao_medico",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_verificacao_card_cartao_id1",
                table: "verificacao_card",
                column: "cartao_id1");

            migrationBuilder.CreateIndex(
                name: "IX_verificacao_card_medico_id",
                table: "verificacao_card",
                column: "medico_id");

            migrationBuilder.CreateIndex(
                name: "IX_sessao_chat_usuario_id1",
                table: "sessao_chat",
                column: "usuario_id1");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_chat_remetente_id1",
                table: "mensagem_chat",
                column: "remetente_id1");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_chat_sessao_id1",
                table: "mensagem_chat",
                column: "sessao_id1");

            migrationBuilder.CreateIndex(
                name: "IX_medico_usuario_id1",
                table: "medico",
                column: "usuario_id1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fonte_card_cartao_id1",
                table: "fonte_card",
                column: "cartao_id1");

            migrationBuilder.CreateIndex(
                name: "IX_conteudo_card_autor_id1",
                table: "conteudo_card",
                column: "autor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_certificacao_medico_medico_id1",
                table: "certificacao_medico",
                column: "medico_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_certificacao_medico_medico_medico_id1",
                table: "certificacao_medico",
                column: "medico_id1",
                principalTable: "medico",
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
                name: "FK_fonte_card_conteudo_card_cartao_id1",
                table: "fonte_card",
                column: "cartao_id1",
                principalTable: "conteudo_card",
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
                name: "FK_mensagem_chat_sessao_chat_sessao_id1",
                table: "mensagem_chat",
                column: "sessao_id1",
                principalTable: "sessao_chat",
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
                name: "FK_sessao_chat_usuario_usuario_id1",
                table: "sessao_chat",
                column: "usuario_id1",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_verificacao_card_conteudo_card_cartao_id1",
                table: "verificacao_card",
                column: "cartao_id1",
                principalTable: "conteudo_card",
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
    }
}
