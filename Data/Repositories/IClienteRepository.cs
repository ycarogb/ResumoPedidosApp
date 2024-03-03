using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> GetAllClientes();
        Cliente CreateCliente(string nome, string bairro);
        Cliente UpdateCliente(Cliente clienteUpdate);
    }
}