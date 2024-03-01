using Bogus;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Tests.Helpers;

public static class ResumoPedidoFaker
{
    public static Faker<ResumoPedido> ResumoPedido =>
        new Faker<ResumoPedido>().Rules((faker, resumoPedido) =>
        { 
            resumoPedido.IdCliente = faker.Random.Int(100, 999);
            resumoPedido.IdResumoPedido = faker.Random.Int();
        });
}