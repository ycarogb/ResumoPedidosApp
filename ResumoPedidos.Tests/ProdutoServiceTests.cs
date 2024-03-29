using FluentAssertions;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Helpers;
using Xunit;

namespace ResumoPedidos.Tests
{
    public class ProdutoServiceTests
    {
        [Fact]
        public async Task Cadastra_um_produto()
        {
            var produto = ProdutoFaker.Produto.Generate();

            var produtoRepository = new ProdutoRepository();
            var service = new ProdutoService(produtoRepository);

            var result = service.CadastrarProduto(produto.Descricao, produto.Valor);

            result.IdProduto.Should().NotBe(null);
        }
    }
}