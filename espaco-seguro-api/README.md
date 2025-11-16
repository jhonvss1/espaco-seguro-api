# Espaço Seguro API

API REST em ASP.NET Core 9 organizada em camadas para suportar os fluxos do projeto acadêmico **Espaço Seguro**: autenticação JWT, gestão de usuários, cards editoriais, postagens públicas, comentários/curtidas e o novo módulo de chat assíncrono. Abaixo está toda a documentação funcional baseada no código atual.

---

## Stack e Organização

| Camada | Conteúdo principal |
| --- | --- |
| **1 - Presentation** | Controllers HTTP, rotas `api/*`. Sem lógica de negócio. |
| **2 - Application** | DTOs (Request/Response), mapeadores e services *App* que convertem DTO ↔ domínio. |
| **3 - Domain** | Entidades, enums, regras de negócio, validações (`DomainValidationException`). |
| **4 - Data** | `AppDbContext`, repositórios EF Core, migrations e helpers de infraestrutura. |
| **5 - Infra** | Autenticação/JWT (`FabricadorDeToken`). |

Bibliotecas chave: .NET 9, EF Core 9 + Npgsql, JWT Bearer, Swagger/OpenAPI (habilitado em `Development`).  
Banco: PostgreSQL (connection string `ConnectionStrings:ConexaoPadrao`).

```bash
dotnet restore
dotnet build
dotnet run          # aplica migrations automaticamente no startup
# Swagger dev: https://localhost:<porta>/swagger
```

---

## Visão Geral de Fluxos

```
Auth (JWT) ─┬─> Usuários (CRUD + perfis)
            ├─> Cards editoriais (criação → revisão → publicação)
            ├─> Postagens de usuários (texto, tags, anônimo)
            │    ├─> Comentários
            │    └─> Curtidas (like/unlike)
            └─> Chat (sessões + mensagens)   # NOVO
```

### Convenções de API
- Base URL: `/api/<Controller>` (ex.: `/api/Usuario`, `/api/SessaoChat`).  
- Controllers seguem o padrão `HttpVerb("rota")`; o JSON das requisições espelha os `RequestVm`.  
- Respostas de sucesso retornam DTOs da camada `Response`. Em falhas de domínio, `DomainValidationException` vira `400` com `{ "title": "Falha de validação", "error": "<mensagem>" }`.
- Erros não tratados dentro dos controllers são encapsulados como `BadRequest(ex.Message)`.

### Autenticação
- Controller: `AuthController` (`/api/Auth/login`).  
- `LoginRequestVm` `{ "email": "", "senha": "" }`.  
- Retorno `LoginResponse`: token JWT (`TokenAcesso`), expiração, nome, e-mail e função do usuário.  
- JWT é configurado em `Program.cs` com validação de emissor/audiência e `ClockSkew` de 30s.  
- Controllers atuais não aplicam `[Authorize]`, mas a infraestrutura já está pronta para proteger rotas usando `Permissoes.*` via políticas.

---

## Módulo de Usuários

**Entidades/DTOs**: `Usuario`, `UsuarioRequestVm`, `UsuarioResponse`.  
**Controller**: `UsuarioController` (`/api/Usuario`).  
**Service flow**: Controller → `UsuarioServiceApp` → `UsuarioService` → `UsuarioRepository`.

| Rota | Verbo | Descrição | Request | Resposta |
| --- | --- | --- | --- | --- |
| `/criar` | POST | Cria usuário (hash da senha + validação de termos) | `UsuarioRequestVm` | `201 Created` (sem body). |
| `/obter/{id}` | GET | Busca usuário por Guid | — | `UsuarioResponse` |
| `/obter-todos` | GET | Lista usuários | — | `List<UsuarioResponse>` |
| `/atualizar{id}` | PUT | Atualiza campos preenchidos | `UsuarioRequestVm` | `200 OK` com mensagem |
| `/remover/{id}` | DELETE | Remove usuário | — | `204 No Content` |

**Regras importantes**:
- `AceitouTermos` precisa ser `true` para criação (`UsuarioService.Criar`).  
- Senha é armazenada com `IPasswordHasher` (BCrypt).  
- Atualizações fazem *patch* manual (apenas campos preenchidos movimentam o `EntityEntry`).  
- Exceções de validação resultam em HTTP 400 via middleware em `Program.cs`.

**Exemplo de request** (`POST /api/Usuario/criar`):
```json
{
  "email": "medica@espaco.com",
  "nome": "Ana Souza",
  "dataNascimento": "1995-08-01",
  "cpf": "12345678901",
  "telefone": "+55 11 91234-5678",
  "foto": "https://cdn/avatars/ana.png",
  "aceitouTermos": true,
  "funcao": "Medico",
  "senha": "SenhaForte123",
  "confirmarSenha": "SenhaForte123"
}
```

---

## Módulo de Cards (conteúdo editorial)

**DTOs**: `CardResquestVm`, `CardResponse`.  
**Controller**: `CardController` (`/api/Card`).  
**Fluxo de negócio**: CardService/Repository controlam status e histórico (revisão/publicação).

| Rota | Verbo | Propósito |
| --- | --- | --- |
| `/criar` | POST | Cria um card para o autor informado. |
| `/{id}/enviar-revisao` | POST | Move para revisão (exige `UsuarioId()` do autor logado). |
| `/{id}/iniciar-revisao` | POST | Revisor inicia análise. |
| `/{id}/publicar` | POST | Publica o card. |
| `/{id}/arquivar` | POST | Arquiva o card. |
| `/obter/{id}` | GET | Busca card. |
| `/obter-todos` | GET | Lista geral. |
| `/atualizar/{id}` | PUT | Atualiza conteúdo. |
| `/deletar/{id}` | DELETE | Remove. |

**CardResquestVm**
```json
{
  "autorId": "9f765...",
  "titulo": "Cuidados com saúde mental",
  "resumo": "Checklist para o dia a dia",
  "corpo": "markdown/html",
  "tipo": "TextoCurto",
  "urlMidia": "https://cdn/imagem.png",
  "tags": "saude,ansiedade"
}
```

**Resposta** (`CardResponse`)
```json
{
  "id": "3497...",
  "titulo": "Cuidados com saúde mental",
  "resumo": "Checklist...",
  "corpo": "...",
  "tipo": "TextoCurto",
  "urlMidia": "https://...",
  "tags": "saude,ansiedade",
  "status": "Rascunho|Revisao|Publicado...",
  "autorId": "9f765...",
  "dataPublicacao": "2025-11-16T17:20:00Z",
  "dataRegistro": "2025-11-16T17:20:00Z",
  "dataAtualizacao": "2025-11-16T17:20:00Z",
  "quantidadeFontes": 0,
  "verificacoes": 0
}
```

**Observações para consumidores**:
- Controllers são simples: sempre envie `Guid` válido e trate `400 Bad Request` com mensagens textuais.  
- Use os endpoints de revisão conforme o papel do usuário (edição, curadoria, publicação); a API não valida perfis ainda, logo o front deve aplicar as regras de permissão.

---

## Postagens, Comentários e Curtidas

### Postagens (`PostagemController` – `/api/Postagem`)
| Rota | Verbo | Observações |
| --- | --- | --- |
| `/criar` | POST | Recebe `CriarPostagemRequestVm` (`autorId`, `conteudo`, `anonimo`, `tags`). |
| `/obter/{id}` | GET | query `incluirComentarios=true` retorna `PostagemCompletaResponse`. |
| `/obter-todas` | GET | Lista geral. |
| `/atualizar/{id}` | PUT | Atualiza conteúdo/tags/status. |
| `/remover/{id}` | DELETE | Remove e retorna `204`. |

**PostagemResponse**
```json
{
  "id": "0c87...",
  "autorId": "bc55...",
  "conteudo": "Texto da publicação",
  "anonimo": false,
  "statusPostagem": "Publicado",
  "tags": ["saude","rotina"],
  "contagemCurtidas": 12,
  "contagemComentarios": 3,
  "dataPublicacao": "2025-11-10T23:51:42Z",
  "dataAtualizacao": "2025-11-12T09:10:00Z"
}
```

**Regras chave** (`PostagemRepository`):  
- Atualizações validam transições de status (`Rascunho`, `Publicado`, `Denuncia`, `Removido`).  
- `Anonimo` indica se o autor será exposto nas respostas.  
- `ObterPostagemComComentarios` retorna contagem e lista ordenada dos comentários aprovados.

### Comentários (`ComentarioController` – `/api/Comentario`)
| Rota | Verbo | Detalhes |
| --- | --- | --- |
| `/comentar` | POST | `ComentarioPostagemRequestVm` (autor/postagem/anonimo). |
| `/comentarios` | GET | Lista todos os comentários publicados. |
| `/{id}` | DELETE | Remove comentário. |

`ComentarioPostagemResponse` inclui status (`StatusComentarioPostagem`), contagem de curtidas e `DataPublicacao`.

### Curtidas (`CurtidaController` – `/api/Curtida`)
| Rota | Verbo | Detalhes |
| --- | --- | --- |
| `/{postagemId}?usuarioId=` | POST | Faz like; resposta `{ "liked": true, "likesCount": <int> }`. |
| `/{postagemId}?usuarioId=` | DELETE | Faz unlike; resposta `{ "liked": false, "likesCount": <int> }`. |

`CurtidaPostagemService` garante 1 like por usuário/postagem (índice único no EF).

---

## Chat (Sessões + Mensagens)

### Entidades
- `SessaoChat`: representa a conversa (atributos: `UsuarioId`, `Anonima`, `TipoChat`, `StatusChat`, `IniciadoEm`, `EncerradoEm`, `Mensagens`).  
- `MensagemChat`: `SessaoId`, `RemetenteId`, `Conteudo`, `TipoMensagem`, flags de leitura e timestamps.

### Regras de negócio
`SessaoChatService`:
- Obrigatório escolher `TipoChat`.  
- Sessões identificadas exigem `UsuarioId` válido e usuário `StatusUsuario.Ativo`.  
- Apenas uma sessão ativa por combinação usuário+tipo.  
- Sessões anônimas zeram `UsuarioId`.  
- Encerrar (`StatusChat.Fechado`) só é permitido quando estiver `Ativo`.

`MensagemChatService`:
- Valida se a sessão existe e está ativa antes de enviar.  
- Mensagens precisam de conteúdo (máx. 2000 caracteres) e `RemetenteId` quando a sessão não é anônima.  
- Usuários bloqueados/inativos não podem enviar mensagens.  
- Campo `TipoMensagem` default `Texto`; `MarcarComoLida` atualiza `Lida` + `DataLida`.

### Contractos HTTP

**Sessão** (`SessaoChatController` – `/api/SessaoChat`)
| Rota | Verbo | Request | Resposta |
| --- | --- | --- | --- |
| `/criar` | POST | `SessaoChatRequestVm` `{ "usuarioId": "...", "anonima": false, "tipoChat": "Profissional" }` | `SessaoChatResponse` (contém contagem de mensagens). |
| `/obter/{id}` | GET | — | `SessaoChatResponse`. |
| `/usuario/{usuarioId}` | GET | — | Lista de sessões ordenadas (mais recentes primeiro). |
| `/{id}/encerrar` | PATCH | — | Sessão atualizada. |

**Mensagens** (`MensagemChatController` – `/api/MensagemChat`)
| Rota | Verbo | Request | Resposta |
| --- | --- | --- | --- |
| `/enviar` | POST | `MensagemChatRequestVm` `{ "sessaoId": "...", "remetenteId": "...", "conteudo": "Olá", "tipoMensagem": "Texto" }` | `MensagemChatResponse`. |
| `/sessao/{sessaoId}` | GET | — | Lista ordenada por `dataEnvio`. |
| `/{mensagemId}/marcar-lida` | PATCH | — | `MensagemChatResponse` com `lida=true`. |

**Dicas para o consumidor**:
- Guarde o `SessaoId` criado para continuar a conversa (qualquer usuário pode enviar mensagens desde que respeite as regras de negócio).  
- Sessões anônimas permitem `RemetenteId = null`, mas a aplicação cliente deve decidir como expor isso para fins de suporte/moderação.  
- Use o endpoint de listagem de mensagens para montar o histórico e combine com `MarcarComoLida` para controles de notificação.

---

## Tipos e Enums Principais

| Enum | Valores |
| --- | --- |
| `StatusUsuario` | `Pendente`, `Ativo`, `Inativo`, `Bloqueado` |
| `FuncaoEnum` | `Usuario`, `Medico`, `Curador`, `Administrador` |
| `StatusConteudo` | `Rascunho`, `Revisao`, `Publicado`, `Arquivado`, ... |
| `StatusPostagem` | `Rascunho`, `Publicado`, `Denuncia`, `Removido` |
| `StatusComentarioPostagem` | `Publicado`, `Oculto`, ... |
| `StatusChat` | `Ativo`, `Fechado`, `Abandonado` |
| `TipoChat` | `Suporte`, `Profissional`, `Pessoal` |
| `TipoMensagem` | `Texto`, `Audio`, `Imagem`, `Video`, `Sistema` |

Use sempre os nomes string exatamente como definidos nas enums ao enviar requests.

---

## Padrões de Erro e Diagnóstico

- **400 (Domínio)**: disparado por `DomainValidationException`. Payload:  
  ```json
  { "title": "Falha de validação", "error": "mensagem específica" }
  ```
- **400 (Controller)**: quando a validação básica falha, a resposta traz `BadRequest("<mensagem>")`.  
- **404**: controllers ainda não retornam explicitamente; quando necessário, verifique o corpo (`null` + `200`).  
- **500**: qualquer exceção não tratada.

Recomenda-se ao front:
1. Validar `Guid`s antes do envio.  
2. Exibir mensagens retornadas para o usuário final (principalmente no chat e cards).  
3. Reexecutar chamadas idempotentes (GET/DELETE) em caso de timeout.  
4. Registrar o `error` recebido para suporte.

---

## Boas práticas para integradores

1. **Autenticação**: sempre obtenha um JWT antes de chamar endpoints protegidos e envie em `Authorization: Bearer <token>`.  
2. **Controle de versões**: a API ainda não possui versionamento; mantenha compatibilidade verificando o `README` e o Swagger.  
3. **Idempotência**: `POST /criar` em usuários/cards/postagens cria novos registros; evite duplicidade gerenciando `Guid`s no front quando necessário.  
4. **Timezone**: todas as datas retornam em UTC (`DateTime`). Ajuste no cliente conforme o fuso do usuário.  
5. **Sessões de chat**: defina claramente no front quem “pertence” a cada sessão; o backend permite contato livre entre perfis, cabendo ao cliente bloquear combinações quando aplicável.  
6. **Tratamento de estado**: acompanhe os enums retornados para guiar UX (exibir status do card, impedir ações quando `SessaoChat` estiver `Fechado`, etc.).

---

## Próximos passos (sugestões)
- Aplicar `[Authorize]` nas rotas e associar políticas `Permissoes.*`.  
- Retornar payload completo na criação/atualização de usuários.  
- Expandir o módulo de chat para persistir participantes e permitir notificações push.  
- Adicionar testes automatizados para cobertura das regras de sessão/mensagem.

---

> **Dúvidas ou contribuições**: utilize o README como referência rápida e explore o Swagger para ver o contrato gerado automaticamente a partir dos controllers. Tudo descrito aqui reflete fielmente o estado atual do código-fonte. Buon lavoro! 😊
