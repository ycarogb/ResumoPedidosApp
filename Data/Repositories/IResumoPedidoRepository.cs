using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Data.Repositories;

public interface IResumoPedidoRepository
{
    ResumoPedido CreateResumoPedido(CadastrarResumoPedidoDto dto, decimal valorTotal);
    ResumoPedido GetResumoPedido(Func<ResumoPedido, bool> predicate);
    List<ResumoPedido> GetAllResumoPedidos();
    ResumoPedido UpdateResumoPedido(ResumoPedido resumoPedido);
    bool RemoveResumoPedido(int idResumoPedido);
}