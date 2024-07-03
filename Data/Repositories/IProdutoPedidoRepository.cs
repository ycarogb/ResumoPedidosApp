using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public interface IProdutoPedidoRepository
{
    public Task<List<ProdutoPedido>> CreateProdutosPedidosAsync(IEnumerable<int> idsProduto, int idResumoPedido);
    Task<int> ObterQuantidadeProdutosNoPedidoAsync(int idResumoPedido, int idProduto);
}