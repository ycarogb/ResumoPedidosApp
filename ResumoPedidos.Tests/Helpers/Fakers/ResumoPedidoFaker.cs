using Bogus;
using ResumoPedidos.Domain;
using ResumoPedidos.Tests.Helpers.Fakers;

namespace ResumoPedidos.Tests.Helpers;

public static class ResumoPedidoFaker
{
    public static Faker<ResumoPedido> ResumoPedido =>
        new Faker<ResumoPedido>().Rules((faker, resumoPedido) =>
        { 
            resumoPedido.Cliente = ClienteFaker.Cliente.Generate();
            resumoPedido.IdResumoPedido = faker.Random.Int();
        });
}