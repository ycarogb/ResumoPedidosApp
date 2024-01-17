using FluentAssertions;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Helpers;

namespace ResumoPedidos.Tests
{
    public class ResumoPedidoServiceTests
    {
        [Fact]
        public void Cadastra_um_resumo_de_pedido()
        {
            var resumoPedido = ResumoPedidoFaker.ResumoPedido
            .RuleFor(p => p.Produtos, ProdutoFaker.Produto.Generate(1))
            .Generate();

            var resumoPedidoRepository = new ResumoPedidoRepository();
            var service = new ResumoPedidoService(resumoPedidoRepository);

            var result = service.CreateResumoPedido(resumoPedido.IdCliente, resumoPedido.Produtos);

            result.Id.Should().NotBe(null);
        }

        [Fact]
        public void Cadastra_um_resumo_de_pedido_com_valor_total_correto()
        {
            var resumoPedido = ResumoPedidoFaker.ResumoPedido
            .RuleFor(p => p.Produtos, ProdutoFaker.Produto.Generate(3))
            .Generate();

            var resumoPedidoRepository = new ResumoPedidoRepository();
            var service = new ResumoPedidoService(resumoPedidoRepository);

            var result = service.CreateResumoPedido(resumoPedido.IdCliente, resumoPedido.Produtos);

            var valorTotalEsperado = resumoPedido.Produtos.Select(p => p.Valor).Sum();
            result.ValorTotal.Should().Be(valorTotalEsperado);
        }
    }
}