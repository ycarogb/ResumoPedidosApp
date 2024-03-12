using FluentAssertions;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Helpers;
using Xunit;

namespace ResumoPedidos.Tests
{
    public class ResumoPedidoServiceTests
    {
        private readonly IClienteService _clienteService;

        public ResumoPedidoServiceTests()
        {
            var clienteRepository = new ClienteRepository();
            _clienteService = new ClienteService(clienteRepository);
        }
        [Fact]
        public void Cadastra_um_resumo_de_pedido()
        {
            var clienteTeste = _clienteService.CadastrarCliente("Nome Teste", "Bairro Teste");
            var clienteNoBanco = _clienteService.ObterCliente(p => p.Nome == clienteTeste.Nome);
            var resumoPedido = ResumoPedidoFaker.ResumoPedido
                .RuleFor(p => p.Produtos, ProdutoFaker.Produto.Generate(1))
                .Generate();

            var resumoPedidoRepository = new ResumoPedidoRepository();
            var service = new ResumoPedidoService(resumoPedidoRepository);

            var result = service.CadastrarResumoPedido(resumoPedido.Cliente, resumoPedido.Produtos);

            result.IdResumoPedido.Should().NotBe(null);
        }

        [Fact]
        public void Cadastra_um_resumo_de_pedido_com_valor_total_correto()
        {
            var resumoPedido = ResumoPedidoFaker.ResumoPedido
            .RuleFor(p => p.Produtos, ProdutoFaker.Produto.Generate(3))
            .Generate();

            var resumoPedidoRepository = new ResumoPedidoRepository();
            var service = new ResumoPedidoService(resumoPedidoRepository);

            var result = service.CadastrarResumoPedido(resumoPedido.Cliente, resumoPedido.Produtos);

            var valorTotalEsperado = resumoPedido.Produtos.Select(p => p.Valor).Sum();
            result.ValorTotal.Should().Be(valorTotalEsperado);
        }
    }
}