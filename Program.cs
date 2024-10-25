
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProdutoAPI.Data;
using ProdutoAPI.Repositories;
using ProdutoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com a string de conexão do Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra o repositório na injeção de dependência
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Adiciona HttpClient para o serviço FirebaseAuthService
builder.Services.AddHttpClient<FirebaseAuthService>();

// Adiciona os serviços necessários ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Produtos", Version = "v1" });
});

var app = builder.Build();

// Configurações do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Produtos v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
