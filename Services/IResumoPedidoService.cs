using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Services;

public interface IResumoPedidoService
{
    Task<ResumoPedidoResponseDto> CadastrarResumoPedidoAsync(CadastrarResumoPedidoDto dto);
    ResumoPedido ObterResumoPedido(Func<ResumoPedido, bool> predicate);        
    List<ResumoPedido> ObterTodosOsResumoPedidos();
    ResumoPedido EditarDados(ResumoPedido resumoPedido);
    bool ExcluirResumoPedido(int idResumoPedido);
}