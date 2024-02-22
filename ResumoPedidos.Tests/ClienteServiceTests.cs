using FluentAssertions;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Helpers.Fakers;
using Xunit;

namespace ResumoPedidos.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public async Task Cadastra_um_cliente()
        {
            var cliente = ClienteFaker.Cliente.Generate();

            var clienteRepository = new ClienteRepository();
            var service = new ClienteService(clienteRepository);

            var result = service.CadastrarCliente(cliente.Nome, cliente.Bairro);

            result.Id.Should().NotBe(null);
        }
    } 
}