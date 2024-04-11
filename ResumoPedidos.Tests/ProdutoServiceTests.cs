using FluentAssertions;
using Moq;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Helpers;
using Xunit;

namespace ResumoPedidos.Tests
{
    public class ProdutoServiceTests
    {
        private readonly ProdutoService _service;

        public ProdutoServiceTests()
        {
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            _service = new ProdutoService(produtoRepositoryMock.Object);
        }
        [Fact]
        public async Task Cadastra_um_produto()
        {
            var produto = ProdutoFaker.Produto.Generate();
            
            var result = _service.CadastrarProduto(produto.Descricao, produto.Valor);

            result.IdProduto.Should().NotBe(null);
        }
    }
}