using Microsoft.OpenApi.Models;
using ResumoPedidos.Data;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoPedidoService, ProdutoPedidoService>();
builder.Services.AddScoped<IProdutoPedidoRepository, ProdutoPedidoRepository>();
builder.Services.AddScoped<IResumoPedidoService, ResumoPedidoService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IResumoPedidoRepository, ResumoPedidoRepository>();
builder.Services.AddScoped<ResumoPedidosContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(p =>
{
    p.SwaggerDoc("v1", new OpenApiInfo() { Title = "ResumoPedidosApi", Version = "v1" });
    p.ResolveConflictingActions(q => q.First());
});

var app = builder.Build();

SeedDataBase.Initialize(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();