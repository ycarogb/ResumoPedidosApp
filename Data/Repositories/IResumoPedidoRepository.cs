using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public interface IResumoPedidoRepository
{
    ResumoPedido CreateResumoPedido( int idCliente, List<Produto> produtos, decimal valorTotal );
}