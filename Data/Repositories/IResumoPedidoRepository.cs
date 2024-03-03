using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public interface IResumoPedidoRepository
{
    ResumoPedido CreateResumoPedido( Cliente cliente, List<Produto> produtos, decimal valorTotal );
}