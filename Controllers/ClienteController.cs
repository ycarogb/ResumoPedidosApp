using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(
        IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet("GetById")]
    public Cliente ObterClientePorId(int id)
    {
        var cliente = _clienteService.ObterCliente(p => p.IdCliente == id);
        return cliente;
    }

    [HttpGet("GetClientes")]
    public List<Cliente> ObterClientes()
    {
        var clientes = _clienteService.ObterTodosOsClientes();
        return clientes;
    }

    [HttpPost("Cadastrar")]
    public Cliente Cadastrar(string nome, string bairro)
    {
        var novoCliente = _clienteService.CadastrarCliente(nome, bairro);
        return novoCliente;
    }

    [HttpPost("EditarDados")]
    public Cliente EditarDados(Cliente cliente)
    {
        var clienteEditado = _clienteService.EditarDados(cliente);
        return clienteEditado;
    }

    [HttpDelete("DeletarCliente")]
    public bool ExcluirCliente(Cliente cliente)
    {
        var clienteExcluido = _clienteService.ExcluirCliente(cliente.IdCliente);
        return clienteExcluido;
    }
}
