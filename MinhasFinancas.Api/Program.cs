using MinhasFinancas.Api.Fakes;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurações de Serviços (O que a API sabe fazer)
builder.Services.AddOpenApi();
builder.Services.AddControllers(); // Ensina a API a ler a pasta Controllers

// 2. Injeção de Dependência (A Arquitetura Limpa)
builder.Services.AddScoped<MinhasFinancas.Aplicacao.CasosDeUso.ObterResumoMensal.ObterResumoMensal>();
builder.Services.AddSingleton<MinhasFinancas.Aplicacao.Interfaces.ITransacaoRepositorio, TransacaoRepositorioFake>();
builder.Services.AddSingleton<MinhasFinancas.Aplicacao.Interfaces.IContaRepositorio, ContaRepositorioFake>();
builder.Services.AddSingleton<MinhasFinancas.Aplicacao.Interfaces.ICartaoRepositorio, CartaoRepositorioFake>();

var app = builder.Build();

// 3. Configurações de Pipeline (Como a API responde à internet)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection(); // Desativado para não dar aquele aviso no Linux

// ---> A LINHA QUE FALTAVA! <---
// Isso diz: "Pegue todas as classes que herdam de ControllerBase e crie URLs para elas"
app.MapControllers(); 

// ---> ADICIONE ESTA LINHA AQUI <---
app.MapGet("/ping", () => "A API ESTA VIVA E FUNCIONANDO!");

app.Run();