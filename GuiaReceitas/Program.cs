using GuiaReceitas.Models;
using OpenAI_API;
using OpenAI_API.Completions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("front", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("front");
app.UseHttpsRedirection();

app.MapPost("/gerar-receita", async (IConfiguration configuration, 
    ReceitaDTO receitaDTO) =>
{
    if (string.IsNullOrEmpty(receitaDTO?.Ingrediente))
        return Results.BadRequest("Ingrediente inválido.");

    string resposta = string.Empty;

    var client = new OpenAIAPI(configuration["OpenAiSettings:ApiKey"]);

    var prompt = configuration["OpenAiSettings:Prompt"];
    prompt = prompt.Replace("{ingrediente}", receitaDTO.Ingrediente);

    var result = await client.Completions.CreateCompletionAsync(
        new CompletionRequest 
        {
            Prompt = prompt,
            MaxTokens = 500
        });

    resposta = result.Completions[0].Text;

    resposta = resposta.Replace("\n", string.Empty);
    resposta = resposta.Replace("\t", string.Empty);

    return Results.Ok(new { Resposta = resposta });
})
.WithOpenApi();

app.Run();