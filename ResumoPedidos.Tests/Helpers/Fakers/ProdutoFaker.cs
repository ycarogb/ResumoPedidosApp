using Bogus;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Tests.Helpers;

public static class ProdutoFaker
{
    public static Faker<Produto> Produto =>
        new Faker<Produto>().Rules((faker, produto) =>
        {
            produto.Descricao = faker.Random.String2(50);
            produto.Valor = faker.Random.Decimal(25, 250);
        });
}