using FluentAssertions;
using Moq;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Helpers.Fakers;
using Xunit;

namespace ResumoPedidos.Tests
{
    /*
     * TODO: Ao resolver mapeamento, resolver esses testes
     */
    public class ResumoPedidoServiceTests
    {
        private readonly IClienteService _clienteService;
        private readonly Mock<IResumoPedidoRepository> _resumoPedidoRepositoryMock;

        public ResumoPedidoServiceTests()
        {
            _resumoPedidoRepositoryMock = new Mock<IResumoPedidoRepository>();
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(clienteRepositoryMock.Object);
        }
        [Fact]
        public void Cadastra_um_resumo_de_pedido()
        {
            //TODO: Com nova Infra de teste isso não será feito direto no serviço
            var clienteNoBanco = _clienteService.ObterCliente(p => p.Nome == "Nome Teste");
            var dto = CadastrarResumoPedidoDtoFaker.Dto
                .RuleFor(p => p.IdCliente, clienteNoBanco.IdCliente).Generate();
            var service = new ResumoPedidoService(_resumoPedidoRepositoryMock.Object);

            var result = service.CadastrarResumoPedido(dto);
            var resumoPedidoEsperado = new ResumoPedido()
            {
                Cliente = clienteNoBanco,
                IdCliente = clienteNoBanco.IdCliente,
                Produtos = dto.Produtos
            };

            result.Should().BeEquivalentTo(resumoPedidoEsperado, opt => opt
                .Excluding(p => p.ValorTotal)
                .Excluding(p => p.IdResumoPedido));
        }

        [Fact]
        public void Cadastra_um_resumo_de_pedido_com_valor_total_correto()
        {
            var clienteNoBanco = _clienteService.ObterCliente(p => p.Nome == "Nome Teste");
            var dto = CadastrarResumoPedidoDtoFaker.Dto
                .RuleFor(p => p.IdCliente, clienteNoBanco.IdCliente).Generate();
            var service = new ResumoPedidoService(_resumoPedidoRepositoryMock.Object);

            var result = service.CadastrarResumoPedido(dto);

            var valorTotalEsperado = dto.Produtos.Select(p => p.Valor).Sum();
            result.ValorTotal.Should().Be(valorTotalEsperado);
        }
    }
}