using ResumoPedidos.Domain;

namespace ResumoPedidos.Services
{
    public interface IClienteService
    {
        Cliente CadastrarCliente(string nome, string bairro);
    }
}