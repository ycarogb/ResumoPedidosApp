using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public interface IResumoPedidoService
{
    //TODO: Cadastrar um ResumoPedido ainda leva a cadastrar novos Pedidos e Clientes!! Verificar isso no mapeamento. 
    ResumoPedido CadastrarResumoPedido(Cliente cliente, List<Produto> produtos);
}