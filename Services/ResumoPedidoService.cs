using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;
using ResumoPedidos.Services.Helpers;

namespace ResumoPedidos.Services;

public class ResumoPedidoService : IResumoPedidoService
{
    private readonly IResumoPedidoRepository _repository;

    public ResumoPedidoService(IResumoPedidoRepository repository)
    {   
        _repository = repository;
    }

    public ResumoPedido CadastrarResumoPedido(CadastrarResumoPedidoDto dto)
    {
        var valorTotal = CalcularValorTotal(dto.Produtos);
        var novoResumoPedido = _repository.CreateResumoPedido(dto, valorTotal);
        return novoResumoPedido;
    }

    //TODO: Estudar no livro DDD onde colocar uma calculadora
    private decimal CalcularValorTotal(List<Produto> produtos)
    {
        var calculadora = new CalculadoraDePrecos();
        return calculadora.ObterValorTotal(produtos);
    }
}