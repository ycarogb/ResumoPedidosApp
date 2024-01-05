using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories
{
    public interface IClienteRepository
    {
        Cliente CreateCliente(string nome, string bairro);
    }
}