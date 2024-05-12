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
        try
        {
            var valorTotal = CalcularValorTotal(dto.Produtos);
            var novoResumoPedido = _repository.CreateResumoPedido(dto, valorTotal);
            return novoResumoPedido;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao cadastrar resumoPedido.");
        }
    }

    public ResumoPedido ObterResumoPedido(Func<ResumoPedido, bool> predicate)
    {
        try
        {
            var resumoPedido = _repository.GetResumoPedido(predicate);
            return resumoPedido;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao obter registro de resumoPedido.");
        }
    }

    public List<ResumoPedido> ObterTodosOsResumoPedidos()
    {
        try
        {
            var resumoPedidos = _repository.GetAllResumoPedidos();
            return resumoPedidos;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao obter registro de resumoPedidos.");
        }
    }

    public ResumoPedido EditarDados(ResumoPedido resumoPedido)
    {
        try
        {
            var resumoPedidoEditado = _repository.UpdateResumoPedido(resumoPedido);
            return resumoPedidoEditado;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao editar dados do resumoPedido.");
        }
    }

    public bool ExcluirResumoPedido(int idResumoPedido)
    {
        try
        {
            var resumoPedidoExcluido = _repository.RemoveResumoPedido(idResumoPedido);
            return resumoPedidoExcluido;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao deletar o resumoPedido.");
        }
    }
    
    public decimal CalcularValorTotal(List<Produto> produtos)
    {
        var calculadora = new CalculadoraDePrecos();
        return calculadora.ObterValorTotal(produtos);
    }
}