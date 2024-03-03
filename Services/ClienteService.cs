using ResumoPedidos.Application.DTOs;
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
                throw new Exception("Erro ao cadastrar cliente.");
            }
        }
    }
}