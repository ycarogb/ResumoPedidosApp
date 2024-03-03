using Bogus;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Tests.Helpers.Fakers
{
    public static class ClienteFaker
    {
        public static Faker<Cliente> Cliente =>
        new Faker<Cliente>().Rules((faker, cliente) =>
            {
                cliente.Nome = faker.Random.String2(10);
                cliente.Bairro = faker.Random.String2(10);
            });

    }
}