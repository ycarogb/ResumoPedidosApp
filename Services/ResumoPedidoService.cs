using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;
using ResumoPedidos.Services.Helpers;

namespace ResumoPedidos.Services;

public class ResumoPedidoService : IResumoPedidoService
{
    private readonly IResumoPedidoRepository _repository;

    public ResumoPedidoService(IResumoPedidoRepository repository)
    {   
        _repository = repository;
    }

    public ResumoPedido CadastrarResumoPedido(int idCliente, List<Produto> produtos)
    {
        var valorTotal = CalcularValorTotal(produtos);
        var novoResumoPedido = _repository.CreateResumoPedido(idCliente, produtos, valorTotal);
        return novoResumoPedido;
    }

    private decimal CalcularValorTotal(List<Produto> produtos)
    {
        var calculadora = new CalculadoraDePrecos();
        return calculadora.ObterValorTotal(produtos);
    }
}