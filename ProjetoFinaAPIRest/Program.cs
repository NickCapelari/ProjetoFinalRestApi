using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Contexto>();
builder.Services.AddScoped<LocalEventoService>();
builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<TipoIngressoService>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<ContatoService>();
builder.Services.AddScoped<IngressoService>();
builder.Services.AddScoped<FotoPortifolioService>();
builder.Services.AddScoped<PortifolioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
