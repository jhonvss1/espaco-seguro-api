# Espaço Seguro API

API em ASP.NET Core organizada em camadas para o projeto acadêmico *Espaço Seguro*. A aplicação expõe, até o momento, apenas fluxos de gestão de usuários, persistindo dados em PostgreSQL via Entity Framework Core.

## Stack principal
- .NET 9 (`net9.0`)
- ASP.NET Core Web API
- Entity Framework Core 9 + Npgsql
- Swagger/OpenAPI (habilitado automaticamente em ambiente de desenvolvimento)
- PostgreSQL

## Estrutura em camadas
- `1 - Presentation`: controllers HTTP. Atualmente apenas `UsuarioController`.
- `2 - Application`: DTOs (Request/Response), mapeadores e serviços de aplicação.
- `3 - Domain`: entidades, enums, serviços de domínio e exceções de validação.
- `4 - Data`: `DbContext`, repositórios e migrations do EF Core.

## Como executar localmente
1. Pré-requisitos
   - SDK .NET 9 instalado.
   - Instância PostgreSQL acessível.
2. Configure a connection string em `appsettings.json` (chave `ConnectionStrings:ConexaoPadrao`). Por padrão, aponta para `Host=localhost;Port=5432;DataBase=espaco_seguro;Username=postgres;Password=postgres`.
3. Suba a API:
   ```bash
   dotnet restore
   dotnet run
   ```
   As migrations pendentes são aplicadas automaticamente no startup.
4. Swagger UI (dev): `https://localhost:<porta>/swagger`.

## Contratos de Usuário
Base URL: `/api/Usuario`.

### POST `/criar`
Cria um usuário.

**Request body (`application/json`)**
```json
{
  "email": "usuario@dominio.com",
  "nome": "Fulana da Silva",
  "dataNascimento": "2000-05-12",
  "cpf": "12345678901",
  "telefone": "+55 11 91234-5678",
  "foto": "https://cdn.dominio.com/avatar.png",
  "aceitouTermos": true,
  "funcao": "Usuario",
  "senha": "SenhaForte123",
  "confirmarSenha": "SenhaForte123"
}
```
Campos são opcionais exceto `email`, `nome`, `senha` e `aceitouTermos` (deve ser `true`; caso contrário retorna `400`).

**Resposta de sucesso**
- `201 Created` sem payload (ainda não retorna o usuário criado).

**Falhas comuns**
- `400 Bad Request` com mensagem `"Erro ao criar usuário."` para validações de domínio (ex.: `aceitouTermos = false`) ou erros de persistência.

### GET `/obter/{id}`
Obtém um usuário existente pelo `Guid`.

**Resposta (`application/json`)**
```json
{
  "id": "2b1c13d5-0cbe-4b36-9bba-08dc46e598ae",
  "email": "usuario@dominio.com",
  "nome": "Fulana da Silva",
  "dataNascimento": "2000-05-12",
  "cpf": "12345678901",
  "telefone": "+55 11 91234-5678",
  "foto": "https://cdn.dominio.com/avatar.png",
  "funcao": "Usuario",
  "statusUsuario": "Pendente",
  "aceitouTermos": true,
  "dataAceiteTermos": "2024-05-03T18:25:43.511481Z",
  "dataRegistro": "2024-05-03T18:25:43.511481Z",
  "dataAtualizacao": "2024-05-03T18:25:43.511481Z",
  "ultimoAcesso": null,
  "quantidadeCartoes": 0,
  "quantidadePostagens": 0,
  "quantidadeSessoes": 0
}
```
Notas:
- Datas em UTC (`DateTime`) são serializadas em ISO-8601.
- `quantidadePostagens` e `quantidadeSessoes` ainda refletem a contagem de `Cartoes` por falta de mapeamento específico.

**Códigos possíveis**
- `200 OK` com o objeto acima.
- `400 Bad Request` com mensagem de erro quando o `id` é inválido ou ocorre uma exceção.
- `204 No Content` pretendido quando `id` é vazio, porém o controller atual não retorna explicitamente.

### PUT `/atualizar?id={id}`
Atualiza campos de um usuário existente.

**Query string obrigatória**
- `id` (`Guid`) do usuário a atualizar.

**Request body (`application/json`)** — mesmo contrato de `POST /criar`. Apenas os campos preenchidos são aplicados, demais permanecem inalterados.

**Resposta de sucesso**
- `201 Created` sem payload (comportamento atual do controller).

**Falhas comuns**
- `400 Bad Request` com mensagem `"Erro ao criar usuário."` quando ocorre alguma exceção na atualização.

## Modelos e enums relevantes
- `UsuarioRequestVm`: DTO de entrada, espelha o corpo JSON do POST/PUT.
- `UsuarioResponse`: DTO retornado pelo GET.
- `FuncaoEnum` (`Usuario`, `Medico`, `Editor`, `Administrador`)
- `StatusUsuario` (`Pendente`, `Ativo`, `Inativo`, `Bloqueado`)

## Tratamento de erros
- Exceções de domínio lançam `DomainValidationException`, transformadas em resposta `400` com payload `{ "title": "Falha de validação", "error": "<mensagem>" }` quando não capturadas pelos services. Na camada atual de usuário, erros são encapsulados como `ArgumentException` e retornam apenas a mensagem genérica `"Erro ao criar usuário."`.

## Próximos passos sugeridos
- Ajustar respostas de `POST` e `PUT` para retornarem o `UsuarioResponse` criado/atualizado.
- Unificar o pipeline de erros para preservar mensagens de domínio no controller.
