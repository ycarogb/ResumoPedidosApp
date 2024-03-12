using Bogus;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Tests.Helpers.Fakers;

public class ProdutoPedidoFaker
{
    public static Faker<ProdutoPedido> ProdutoPedido =>
        new Faker<ProdutoPedido>().Rules((faker, produtoPedido) =>
        {
            produtoPedido.Produto = ProdutoFaker.Produto.Generate();
            produtoPedido.IdProduto = produtoPedido.Produto.IdProduto;
            produtoPedido.ResumoPedido = ResumoPedidoFaker.ResumoPedido.Generate();
            produtoPedido.IdResumoPedido = produtoPedido.ResumoPedido.IdResumoPedido;
            produtoPedido.ValorVendido = faker.Random.Decimal(1, 5000);
        });
}