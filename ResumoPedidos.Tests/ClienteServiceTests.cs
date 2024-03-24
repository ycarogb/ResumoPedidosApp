using FluentAssertions;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Base;
using ResumoPedidos.Tests.Fixtures;
using ResumoPedidos.Tests.Helpers.Fakers;
using Xunit;

namespace ResumoPedidos.Tests
{
    //TODO: Criar uma infraestrutura de teste em que nao se salve direto no banco de dados. Testes de Integração!! 
    public class ClienteServiceTests : ResumoPedidosTestBase, IClassFixture<ResumoPedidoTestFixture>
    {
        //TODO: Criar testes para GetClientes
        private readonly ClienteService _service;
        public ClienteServiceTests(ResumoPedidoTestFixture fixture) : base(fixture)
        {
            var repository = new ClienteRepository();
            _service = new ClienteService(repository);

        }
        
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
            _service.CadastrarCliente(cliente.Nome, cliente.Bairro);
            var clienteNoBanco = _service.ObterCliente(p => p.Nome == cliente.Nome);
            var clienteComNovasInformacoes = new Cliente()
            {
                Bairro = clienteNoBanco.Bairro,
                IdCliente = clienteNoBanco.IdCliente,
                Nome = "novo nome"
            };
            
            var result = _service.AtualizarDadosCliente(clienteComNovasInformacoes);

            result.Nome.Should().Be(clienteComNovasInformacoes.Nome);
        }
    } 
}
