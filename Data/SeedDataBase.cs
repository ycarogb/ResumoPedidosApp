using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data
{
    public static class SeedDataBase
    {
        public static void Initialize(IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<ResumoPedidosContext>();
                context.Database.Migrate();

                if (!context.Produto.Any())
                {
                    context.Produto.Add(new Produto
                    {
                        Descricao = "Quiche",
                        Valor = 85
                    });
                }
                
                if (!context.Cliente.Any())
                {
                    context.Cliente.Add(new Cliente()
                    {
                        Nome = "Cliente Seed",
                        Bairro = "Bairro Seed"
                    });
                }
                
                if (!context.ResumoPedidos.Any())
                {
                    context.ResumoPedidos.Add(new ResumoPedido()
                    {
                        IdCliente = 222,
                        ValorTotal = 100
                    });
                }
                
                if (!context.ProdutoPedido.Any())
                {
                    context.ProdutoPedido.Add(new ProdutoPedido()
                    {
                        IdProduto = 1,
                        IdResumoPedido = 1
                    });
                }
                
                context.SaveChanges();
                context.SaveChanges();
                
                
            }
        }
    }
}