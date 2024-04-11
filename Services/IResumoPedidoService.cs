using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Services;

public interface IResumoPedidoService
{
    //TODO: Cadastrar um ResumoPedido ainda leva a cadastrar novos Pedidos e ResumoPedidos!! Verificar isso no mapeamento. 
    ResumoPedido CadastrarResumoPedido(CadastrarResumoPedidoDto dto);
    ResumoPedido ObterResumoPedido(Func<ResumoPedido, bool> predicate);        
    List<ResumoPedido> ObterTodosOsResumoPedidos();
    ResumoPedido EditarDados(ResumoPedido resumoPedido);
    bool ExcluirResumoPedido(int idResumoPedido);
}