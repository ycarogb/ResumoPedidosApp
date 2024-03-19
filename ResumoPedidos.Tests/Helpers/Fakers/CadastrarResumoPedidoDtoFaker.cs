using Bogus;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Tests.Helpers.Fakers;

public static class CadastrarResumoPedidoDtoFaker
{
    public static Faker<CadastrarResumoPedidoDto> Dto =>
        new Faker<CadastrarResumoPedidoDto>().Rules((faker, dto) =>
        {
            dto.Produtos = ProdutoFaker.Produto.Generate(2);
            dto.IdCliente = faker.Random.Int(500, 100000);
        });
}