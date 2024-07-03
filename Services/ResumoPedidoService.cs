using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;
using ResumoPedidos.Services.Helpers;

namespace ResumoPedidos.Services;

public class ResumoPedidoService : IResumoPedidoService
{
    private readonly IResumoPedidoRepository _repository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoPedidoRepository _produtoResumoRepository;
    private readonly ResumoPedidoHelper _helper;
    private readonly IProdutoService _produtoSevice;

    public ResumoPedidoService(
        IResumoPedidoRepository repository, 
        IClienteRepository clienteRepository, 
        IProdutoPedidoRepository produtoResumoRepository,
        ResumoPedidoHelper helper, 
        IProdutoService produtoSevice)
    {
        _repository = repository;
        _clienteRepository = clienteRepository;
        _produtoResumoRepository = produtoResumoRepository;
        _helper = helper;
        _produtoSevice = produtoSevice;
    }

    public async Task<ResumoPedidoResponseDto> CadastrarResumoPedidoAsync(CadastrarResumoPedidoDto dto)
    {
        try
        {
            var idsProdutosDoPedido = dto.Produtos.Select(q => q.IdProduto);
            var produtosDoPedido = _produtoSevice.ObterProdutos(p => idsProdutosDoPedido.Contains(p.IdProduto));
            var valorTotal = CalcularValorTotal(produtosDoPedido);
            var cliente = _clienteRepository.GetCliente(p => p.IdCliente == dto.IdCliente);
            var resumoPedidoNoBanco = _repository.CreateResumoPedido(cliente.IdCliente, valorTotal);
            await _produtoResumoRepository.CreateProdutosPedidosAsync(idsProdutosDoPedido, resumoPedidoNoBanco.IdResumoPedido);

            var result = new ResumoPedidoResponseDto()
            {
                ResumoPedidoTexto = await _helper.CriaTextoAsync(cliente, resumoPedidoNoBanco, produtosDoPedido)
            };
            
            return result;
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