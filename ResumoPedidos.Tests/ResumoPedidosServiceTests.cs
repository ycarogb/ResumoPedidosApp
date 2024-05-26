using FluentAssertions;
using Moq;
using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;
using ResumoPedidos.Tests.Fakers;

namespace ResumoPedidos.Tests;

public class ResumoPedidoServiceTest
{
    private readonly ResumoPedidoService _service;

    public ResumoPedidoServiceTest()
    {
        var repository = new Mock<IResumoPedidoRepository>();
        _service = new ResumoPedidoService(repository.Object);
    }


    [Fact]
    public void Retorna_valor_total_do_pedido()
    {
        var produto1 = ProdutoFaker.Faker.RuleFor(p => p.Valor, 100).Generate();
        var produto2 = ProdutoFaker.Faker.RuleFor(p => p.Valor, 200).Generate();
        var produto3 = ProdutoFaker.Faker.RuleFor(p => p.Valor, 300).Generate();
        var produtosDoPedido = new List<Produto>() { produto1, produto2, produto3 };
        
        var result = _service.CalcularValorTotal(produtosDoPedido);

        result.Should().Be(600);
    }
}