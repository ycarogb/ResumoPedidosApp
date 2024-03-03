using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IResumoPedidoService
{
    ResumoPedido CadastrarResumoPedido(Cliente cliente, List<Produto> produtos);
}