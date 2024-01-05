using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IProdutoService
{
    Produto CreateProduto(string descricao, decimal valor);
}