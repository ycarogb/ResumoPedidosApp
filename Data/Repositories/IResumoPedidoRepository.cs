using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public interface IResumoPedidoRepository
{
    ResumoPedido CreateResumoPedido(int idCliente, decimal valorTotal);
    ResumoPedido GetResumoPedido(Func<ResumoPedido, bool> predicate);
    List<ResumoPedido> GetAllResumoPedidos();
    ResumoPedido UpdateResumoPedido(ResumoPedido resumoPedido);
    bool RemoveResumoPedido(int idResumoPedido);
}