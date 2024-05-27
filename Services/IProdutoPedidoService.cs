using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IProdutoPedidoService
{
    public Task<List<Produto>> ObterProdutosPorResumoPedidoAsync(int idResumoPedido);
}