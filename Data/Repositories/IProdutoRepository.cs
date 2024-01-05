using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public interface IProdutoRepository
{
    Produto CreateProduto(string descricao, decimal valor);
}