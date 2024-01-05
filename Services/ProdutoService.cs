using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;
    public ProdutoService(IProdutoRepository repository)
    {   
        _repository = repository;
    }
    public Produto CreateProduto(string descricao, decimal valor)
    {
        var novoProduto = _repository.CreateProduto(descricao, valor);
        return novoProduto;
    }
}