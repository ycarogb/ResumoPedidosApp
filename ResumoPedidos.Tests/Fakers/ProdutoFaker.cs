using Bogus;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Tests.Fakers;

public static class ProdutoFaker
{
    public static Faker<Produto> Faker =>
        new Faker<Produto>().Rules((faker, produto) =>
        {
            produto.IdProduto = faker.IndexGlobal;
            produto.Descricao = faker.Random.String2(15);
            produto.Valor = faker.Random.Decimal(0, 1000);
        });
}