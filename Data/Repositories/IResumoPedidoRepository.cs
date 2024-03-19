using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Data.Repositories;

public interface IResumoPedidoRepository
{
    ResumoPedido CreateResumoPedido(CadastrarResumoPedidoDto dto, decimal valorTotal);
}