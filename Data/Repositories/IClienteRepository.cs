using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories
{
    public interface IClienteRepository
    {
        Cliente GetCliente(Func<Cliente, bool> predicate);
        List<Cliente> GetAllClientes();
        Cliente CreateCliente(string nome, string bairro);
        Cliente UpdateCliente(Cliente cliente);
        bool RemoveCliente(int idCliente);
    }
}