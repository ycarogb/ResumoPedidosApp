using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IProdutoService
{
    Produto CadastrarProduto(string descricao, decimal valor);
    Produto ObterProduto(Func<Produto, bool> predicate);
    List<Produto> ObterProdutos(Func<Produto, bool> predicate);
    List<Produto> ObterTodosOsProdutos();
    Produto EditarDados(Produto produto);
    bool ExcluirProduto(int idProduto);
}
