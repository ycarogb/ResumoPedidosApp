using ResumoPedidos.Domain;

namespace ResumoPedidos.Services
{
    public interface IClienteService
    {
        List<Cliente> ObterTodosOsClientes();
        Cliente CadastrarCliente(string nome, string bairro);
    }
}