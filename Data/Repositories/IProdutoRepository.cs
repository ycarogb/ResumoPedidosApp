using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public interface IProdutoRepository
{
    Produto GetProduto(Func<Produto, bool> predicate);
    List<Produto> GetProdutos(Func<Produto, bool> predicate);
    List<Produto> GetAllProdutos();
    Produto CreateProduto(string descricao, decimal valor);
    Produto UpdateProduto(Produto produto);
    bool RemoveProduto(int idProduto);
}
