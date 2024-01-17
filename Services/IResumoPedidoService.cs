using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IResumoPedidoService
{
    ResumoPedido CreateResumoPedido(int idCliente, List<Produto> produtos);
}