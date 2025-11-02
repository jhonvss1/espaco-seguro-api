using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace espaco_seguro_api.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    senha_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    funcao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    foto = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    aceitou_termos = table.Column<bool>(type: "boolean", nullable: false),
                    data_aceite_termos = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UltimoAcesso = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "conteudo_card",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    resumo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    corpo = table.Column<string>(type: "text", nullable: false),
                    tipo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    url_midia = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    tags = table.Column<string>(type: "jsonb", nullable: false),
                    status = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    autor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_publicacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    autor_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conteudo_card", x => x.id);
                    table.ForeignKey(
                        name: "FK_conteudo_card_Usuarios_autor_id1",
                        column: x => x.autor_id1,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    crm = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    uf_crm = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    especialidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status_verificacao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    observacoes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    data_verificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    verificado_por = table.Column<Guid>(type: "uuid", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usuario_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_medico_Usuarios_usuario_id1",
                        column: x => x.usuario_id1,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postagem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    autor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    conteudo = table.Column<string>(type: "text", nullable: false),
                    anonimo = table.Column<bool>(type: "boolean", nullable: false),
                    StatusPostagem = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Tags = table.Column<string>(type: "jsonb", nullable: false),
                    contagem_curtidas = table.Column<int>(type: "integer", nullable: false),
                    contagem_comentarios = table.Column<int>(type: "integer", nullable: false),
                    data_publicacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    autor_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_postagem_Usuarios_autor_id1",
                        column: x => x.autor_id1,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sessao_chat",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: true),
                    anonima = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    tipo_chat = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    data_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    usuario_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessao_chat", x => x.id);
                    table.ForeignKey(
                        name: "FK_sessao_chat_Usuarios_usuario_id1",
                        column: x => x.usuario_id1,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fonte_card",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    cartao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    publicador = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fonte_primaria = table.Column<bool>(type: "boolean", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cartao_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fonte_card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fonte_card_conteudo_card_cartao_id1",
                        column: x => x.cartao_id1,
                        principalTable: "conteudo_card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "verificacao_card",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cartao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    curador_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fonte_primaria_ok = table.Column<bool>(type: "boolean", nullable: false),
                    afirmacoes_conferidas = table.Column<bool>(type: "boolean", nullable: false),
                    linguagem_acessivel = table.Column<bool>(type: "boolean", nullable: false),
                    sem_prescricao_medica = table.Column<bool>(type: "boolean", nullable: false),
                    sem_alarmismo = table.Column<bool>(type: "boolean", nullable: false),
                    observacoes = table.Column<string>(type: "text", nullable: false),
                    status_verificacao_card = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_verificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cartao_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    medico_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verificacao_card", x => x.id);
                    table.ForeignKey(
                        name: "FK_verificacao_card_Usuarios_medico_id",
                        column: x => x.medico_id,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_verificacao_card_conteudo_card_cartao_id1",
                        column: x => x.cartao_id1,
                        principalTable: "conteudo_card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "certificacao_medico",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    medico_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_certificacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero_documento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    url_certificado = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    data_emissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_validadade = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    medico_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificacao_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_certificacao_medico_medico_medico_id1",
                        column: x => x.medico_id1,
                        principalTable: "medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentario_postagem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    postagem_id = table.Column<Guid>(type: "uuid", nullable: false),
                    autor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    conteudo = table.Column<string>(type: "text", nullable: false),
                    anonimo = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    contagem_curtidas = table.Column<int>(type: "integer", nullable: false),
                    data_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    postagem_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    autor_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentario_postagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_comentario_postagem_Usuarios_autor_id1",
                        column: x => x.autor_id1,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comentario_postagem_postagem_postagem_id1",
                        column: x => x.postagem_id1,
                        principalTable: "postagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mensagem_chat",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sessao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    remetente_id = table.Column<Guid>(type: "uuid", nullable: true),
                    conteudo = table.Column<string>(type: "text", nullable: false),
                    tipo_mensagem = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    lida = table.Column<bool>(type: "boolean", nullable: false),
                    data_lida = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_envio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sessao_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    remetente_id1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mensagem_chat", x => x.id);
                    table.ForeignKey(
                        name: "FK_mensagem_chat_Usuarios_remetente_id1",
                        column: x => x.remetente_id1,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mensagem_chat_sessao_chat_sessao_id1",
                        column: x => x.sessao_id1,
                        principalTable: "sessao_chat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_certificacao_medico_medico_id1",
                table: "certificacao_medico",
                column: "medico_id1");

            migrationBuilder.CreateIndex(
                name: "IX_comentario_postagem_autor_id1",
                table: "comentario_postagem",
                column: "autor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_comentario_postagem_postagem_id1",
                table: "comentario_postagem",
                column: "postagem_id1");

            migrationBuilder.CreateIndex(
                name: "IX_conteudo_card_autor_id1",
                table: "conteudo_card",
                column: "autor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_fonte_card_cartao_id1",
                table: "fonte_card",
                column: "cartao_id1");

            migrationBuilder.CreateIndex(
                name: "IX_medico_usuario_id1",
                table: "medico",
                column: "usuario_id1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_chat_remetente_id1",
                table: "mensagem_chat",
                column: "remetente_id1");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_chat_sessao_id1",
                table: "mensagem_chat",
                column: "sessao_id1");

            migrationBuilder.CreateIndex(
                name: "IX_postagem_autor_id1",
                table: "postagem",
                column: "autor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_sessao_chat_usuario_id1",
                table: "sessao_chat",
                column: "usuario_id1");

            migrationBuilder.CreateIndex(
                name: "IX_verificacao_card_cartao_id1",
                table: "verificacao_card",
                column: "cartao_id1");

            migrationBuilder.CreateIndex(
                name: "IX_verificacao_card_medico_id",
                table: "verificacao_card",
                column: "medico_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "certificacao_medico");

            migrationBuilder.DropTable(
                name: "comentario_postagem");

            migrationBuilder.DropTable(
                name: "fonte_card");

            migrationBuilder.DropTable(
                name: "mensagem_chat");

            migrationBuilder.DropTable(
                name: "verificacao_card");

            migrationBuilder.DropTable(
                name: "medico");

            migrationBuilder.DropTable(
                name: "postagem");

            migrationBuilder.DropTable(
                name: "sessao_chat");

            migrationBuilder.DropTable(
                name: "conteudo_card");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
