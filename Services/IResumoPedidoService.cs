using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IResumoPedidoService
{
    ResumoPedido CadastrarResumoPedido(int idCliente, List<Produto> produtos);
}