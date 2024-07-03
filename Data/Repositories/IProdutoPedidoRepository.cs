using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Data.Repositories;

public interface IProdutoPedidoRepository
{
    public Task<List<ProdutoPedido>> CreateProdutosPedidosAsync(List<ProdutoResumoPedidoDto> produtos,
        int idResumoPedido);
    Task<int> ObterQuantidadeProdutosNoPedidoAsync(int idResumoPedido, int idProduto);
}