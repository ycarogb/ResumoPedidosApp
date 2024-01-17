using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IProdutoService
{
    Produto CadastrarProduto(string descricao, decimal valor);
}