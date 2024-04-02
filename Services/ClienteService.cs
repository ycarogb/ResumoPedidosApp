using ResumoPedidos.Data.Repositories;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        
        public Cliente CadastrarCliente(string nome, string bairro)
        {
            try
            {
                var novoCliente = _clienteRepository.CreateCliente(nome, bairro);
                return novoCliente;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar cliente.");
            }
        }

        public Cliente EditarDados(Cliente cliente)
        {
            try
            {
                var clienteEditado = _clienteRepository.UpdateCliente(cliente);
                return clienteEditado;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar dados do cliente.");
            }
        }

        public bool ExcluirCliente(int idCliente)
        {
            try
            {
                var clienteExcluido = _clienteRepository.RemoveCliente(idCliente);
                return clienteExcluido;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao deletar o cliente.");
            }
        }

        public Cliente AtualizarDadosCliente(Cliente cliente)
        {
            try
            {
                var novoCliente = _clienteRepository.UpdateCliente(cliente);
                return novoCliente;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar cliente.");
            }
        }

        public List<Cliente> ObterTodosOsClientes()
        {
            try
            {
                var clientes = _clienteRepository.GetAllClientes();
                return clientes;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter registro de clientes.");
            }
        }

        public Cliente ObterCliente(Func<Cliente, bool> predicate)
        {
            try
            {
                var cliente = _clienteRepository.GetCliente(predicate);
                return cliente;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao obter registro de cliente.");
            }
        }
    }
}
