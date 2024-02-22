using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data
{
    public class SeedDataBase
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
                        Id = 1,
                        Valor = 85
                    });
                }
                
                if (!context.Cliente.Any())
                {
                    context.Cliente.Add(new Cliente()
                    {
                        Nome = "Cliente Seed",
                        Id = 1,
                        Bairro = "Bairro Seed"
                    });
                }
                context.SaveChanges();
            }
        }
    }
}