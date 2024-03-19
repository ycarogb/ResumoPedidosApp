using ResumoPedidos.Domain;

namespace ResumoPedidos.Services
{
    public interface IClienteService
    {
        Cliente ObterCliente(Func<Cliente, bool> predicate);
        List<Cliente> ObterTodosOsClientes();
        Cliente CadastrarCliente(string nome, string bairro);
        Cliente EditarDados(Cliente cliente);
    }
}