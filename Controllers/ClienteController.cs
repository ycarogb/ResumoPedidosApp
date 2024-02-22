using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("cliente")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IClienteService _clienteService;

    public ClienteController(
        ILogger<ClienteController> logger,
        IClienteService clienteService)
    {
        _logger = logger;
        _clienteService = clienteService;
    }

    [HttpGet(Name = "GetClientes")]
    public IEnumerable<Cliente> ObterClientes()
    {
        return new List<Cliente>();
    }

    [HttpPost(Name = "CadastrarCliente")]
    public Cliente CadastrarCliente(string nome, string bairro)
    {
        var novoCliente = _clienteService.CadastrarCliente(nome, bairro);
        return novoCliente;
    }
}