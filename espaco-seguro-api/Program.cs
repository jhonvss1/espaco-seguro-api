using System.Text;
using espaco_seguro_api._2___Application.Interfaces.Auth;
using espaco_seguro_api._2___Application.Interfaces.Postagem;
using espaco_seguro_api._2___Application.JwtSettings;
using espaco_seguro_api._2___Application.ServiceApp;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.ComentarioPostagem;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.Chat;
using espaco_seguro_api._3___Domain.Auth;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;
using espaco_seguro_api._3___Domain.Interfaces.Services.Chat;
using espaco_seguro_api._3___Domain.Security;
using espaco_seguro_api._3___Domain.Services;
using espaco_seguro_api._3___Domain.Services.Chat;
using espaco_seguro_api._3___Domain.Services.Postagem.ComentarioPostagem;
using espaco_seguro_api._3___Domain.Services.Security;
using espaco_seguro_api._4___Data;
using espaco_seguro_api._4___Data.Helpers;
using espaco_seguro_api._4___Data.Repositories;
using espaco_seguro_api._5___Infra.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    // Doc principal
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Espaço Seguro API",
        Version = "v1",
        Description = "API do Espaço Seguro"
    });
    
    var scheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Informe: Bearer"
    };
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        [ scheme ] = Array.Empty<string>()
    });

});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins(
                "http://localhost:4200",
                "https://espaco-seguro-web.onrender.com"
            );
    });
});


builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPadrao")));

var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtSettings = new JwtSettings();
jwtSection.Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);

// ====== Authentication (JWT Bearer) ======
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false; // true em produção com HTTPS
        opt.SaveToken = true;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = key,
            ClockSkew = TimeSpan.FromSeconds(30)
        };

        opt.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = ctx =>
            {
                Console.WriteLine("AUTH FAILED: " + ctx.Exception.Message);
                return Task.CompletedTask;
            },
            OnChallenge = ctx =>
            {
                Console.WriteLine("AUTH CHALLENGE: " + ctx.ErrorDescription);
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioServiceApp, UsuarioServiceApp>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardServiceApp, CardServiceApp>();
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
builder.Services.AddScoped<IPostagemService, PostagemService>();
builder.Services.AddScoped<IPostagemServiceApp, PostagemServiceApp>();
builder.Services.AddScoped<ICurtidaPostagemRepository, CurtidaPostagemRepository>();
builder.Services.AddScoped<ICurtidaPostagemService, CurtidaPostagemService>();
builder.Services.AddScoped<ICurtidaPostagemServiceApp,  CurtidaPostagemServiceApp>();
builder.Services.AddScoped<IComentarioPostagemRepository,  ComentarioPostagemRepository>();
builder.Services.AddScoped<IComentarioPostagemService, ComentarioPostagemService>();
builder.Services.AddScoped<IComentarioPostagemServiceApp, ComentarioPostagemServiceApp>();
builder.Services.AddScoped<ISessaoChatRepository, SessaoChatRepository>();
builder.Services.AddScoped<IMensagemChatRepository, MensagemChatRepository>();
builder.Services.AddScoped<ISessaoChatService, SessaoChatService>();
builder.Services.AddScoped<IMensagemChatService, MensagemChatService>();
builder.Services.AddScoped<ISessaoChatServiceApp, SessaoChatServiceApp>();
builder.Services.AddScoped<IMensagemChatServiceApp, MensagemChatServiceApp>();
builder.Services.AddScoped<IFabricadordeToken, FabricadorDeToken>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginServiceApp, LoginServiceApp>();
builder.Services.AddScoped<IPasswordHasher, BcryptPaswordHasher>();
builder.Services.AddScoped<Helpers>();


// ====== Authorization (Policies por permissão) ======
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Permissoes.CardCriar,         p => p.RequireClaim("perm", Permissoes.CardCriar));
    options.AddPolicy(Permissoes.CardEditar,        p => p.RequireClaim("perm", Permissoes.CardEditar));
    options.AddPolicy(Permissoes.CardEnviarRevisao, p => p.RequireClaim("perm", Permissoes.CardEnviarRevisao));
    options.AddPolicy(Permissoes.CardRevisar,       p => p.RequireClaim("perm", Permissoes.CardRevisar));
    options.AddPolicy(Permissoes.CardPublicar,      p => p.RequireClaim("perm", Permissoes.CardPublicar));
    options.AddPolicy(Permissoes.CardArquivar,      p => p.RequireClaim("perm", Permissoes.CardArquivar));
    options.AddPolicy(Permissoes.CardDeletar,       p => p.RequireClaim("perm", Permissoes.CardDeletar));
    options.AddPolicy(Permissoes.CardListar,        p => p.RequireClaim("perm", Permissoes.CardListar));
});


var app = builder.Build();

if (builder.Environment.IsProduction())
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Espaço Seguro API v1");
    });
}

// aplica as migrations automaticamente quando sobe o container docker
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Use(async (ctx, next) =>
{
    try { await next(); }
    catch (DomainValidationException ex)
    {
        ctx.Response.StatusCode = StatusCodes.Status400BadRequest;
        await ctx.Response.WriteAsJsonAsync(new { title = "Falha de validação", error = ex.Message });
    }
});


app.UseHttpsRedirection();


app.UseCors("CorsPolicy");


app.UseAuthentication();   
app.UseAuthorization();

app.MapControllers();

app.Run();
