using ResumoPedidos.Application.DTOs;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories
{
    public interface IClienteRepository
    {
        Cliente CreateCliente(string nome, string bairro);
        Cliente UpdateCliente(ClienteUpdate clienteUpdate);
    }
}