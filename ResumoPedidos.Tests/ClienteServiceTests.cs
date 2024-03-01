using FluentAssertions;
using ResumoPedidos.Application.DTOs;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Helpers.Fakers;
using Xunit;

namespace ResumoPedidos.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public void Cadastra_um_cliente()
        {
            var cliente = ClienteFaker.Cliente.Generate();

            var clienteRepository = new ClienteRepository();
            var service = new ClienteService(clienteRepository);

            var result = service.CadastrarCliente(cliente.Nome, cliente.Bairro);

            result.IdCliente.Should().NotBe(null);
        }

        [Fact]
        public void Atualiza_informacoes_de_um_cliente()
        {
            var cliente = ClienteFaker.Cliente.Generate();
            var clienteComNovasInformacoes = new ClienteUpdate() { Nome = "Novo nome" };
            var clienteRepository = new ClienteRepository();
            var service = new ClienteService(clienteRepository);

            var result = service.AtualizarDadosCliente(clienteComNovasInformacoes);

            result.Nome.Should().Be(clienteComNovasInformacoes.Nome);
        }
    } 
}