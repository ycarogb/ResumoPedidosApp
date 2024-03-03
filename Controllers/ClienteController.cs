using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("cliente")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(
        IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet(Name = "GetClientes")]
    public List<Cliente> ObterClientes()
    {
        var clientes = _clienteService.ObterTodosOsClientes();
        return clientes;
    }

    [HttpPost(Name = "CadastrarCliente")]
    public Cliente CadastrarCliente(string nome, string bairro)
    {
        var novoCliente = _clienteService.CadastrarCliente(nome, bairro);
        return novoCliente;
    }
}