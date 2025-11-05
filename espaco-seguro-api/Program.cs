using espaco_seguro_api._2___Application.Interfaces.Postagem;
using espaco_seguro_api._2___Application.ServiceApp;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp;
using espaco_seguro_api._2___Application.ServiceApp.IServiceApp.ComentarioPostagem;
using espaco_seguro_api._3___Domain.Entities;
using espaco_seguro_api._3___Domain.Exceptions;
using espaco_seguro_api._3___Domain.Interfaces.Repositories;
using espaco_seguro_api._3___Domain.Interfaces.Services;
using espaco_seguro_api._3___Domain.Services;
using espaco_seguro_api._3___Domain.Services.Postagem.ComentarioPostagem;
using espaco_seguro_api._4___Data;
using espaco_seguro_api._4___Data.Helpers;
using espaco_seguro_api._4___Data.Repositories;
using Microsoft.EntityFrameworkCore;
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

    // // JWT Bearer
    // var securityScheme = new OpenApiSecurityScheme
    // {
    //     Name = "Authorization",
    //     Description = "Informe o token JWT: Bearer {seu_token}",
    //     In = ParameterLocation.Header,
    //     Type = SecuritySchemeType.Http,
    //     Scheme = "bearer",
    //     BearerFormat = "JWT",
    //     Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
    // };
    // opt.AddSecurityDefinition("Bearer", securityScheme);
    // opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    // {
    //     [securityScheme] = new string[] {}
    // });
    
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPadrao")));

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

builder.Services.AddScoped<Helpers>();

var app = builder.Build();

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

// Mapeia os controllers (necessário para aparecer no Swagger)
app.MapControllers();

app.Run();