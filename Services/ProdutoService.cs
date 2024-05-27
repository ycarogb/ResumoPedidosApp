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

    public Produto CadastrarProduto(string descricao, decimal valor)
    {
        var novoProduto = _repository.CreateProduto(descricao, valor);
        return novoProduto;
    }

    public Produto ObterProduto(Func<Produto, bool> predicate)
    {
        try
        {
            var produto = _repository.GetProduto(predicate);
            return produto;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao obter registro de produto.");
        }
    }

    public List<Produto> ObterProdutos(Func<Produto, bool> predicate)
    {
        try
        {
            var produtos = _repository.GetProdutos(predicate);
            return produtos;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao obter registros de produtos.");
        }
    }

    public List<Produto> ObterTodosOsProdutos()
    {
        try
        {
            var produtos = _repository.GetAllProdutos();
            return produtos;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao obter registro de produtos.");
        }
    }

    public Produto EditarDados(Produto produto)
    {
        try
        {
            var produtoEditado = _repository.UpdateProduto(produto);
            return produtoEditado;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao editar dados do produto.");
        }
    }

    public bool ExcluirProduto(int idProduto)
    {
        try
        {
            var produtoExcluido = _repository.RemoveProduto(idProduto);
            return produtoExcluido;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao deletar o produto.");
        }
    }
}
