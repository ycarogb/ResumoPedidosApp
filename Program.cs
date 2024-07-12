using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ResumoPedidos.Data;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;
using ResumoPedidos.Services.Autenticacao;
using ResumoPedidos.Services.Helpers;


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
builder.Services.AddScoped<ResumoPedidoHelper>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(p =>
{
    p.SwaggerDoc("v1", new OpenApiInfo() { Title = "ResumoPedidosApi", Version = "v1" });
    p.ResolveConflictingActions(q => q.First());
});

builder.Services.AddControllersWithViews();
var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(p =>
{
    /*Configura esquema de configuração*/
    p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(p =>
{
    p.RequireHttpsMetadata = false;
    p.SaveToken = true;
    p.TokenValidationParameters = new TokenValidationParameters
    {
        /*Validar a chave*/
        ValidateIssuerSigningKey = true,
        /*Qual chave validar*/
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();