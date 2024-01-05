using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("[controller]")]
public class ResumoPedidoController : ControllerBase
{
    private readonly ILogger<ResumoPedidoController> _logger;
    private readonly IClienteService _clienteService;

    public ResumoPedidoController(
        ILogger<ResumoPedidoController> logger,
        IClienteService clienteService)
    {
        _logger = logger;
        _clienteService = clienteService;
    }

    [HttpGet(Name = "GetResumoPedido")]
    public IEnumerable<ResumoPedido> Get()
    {
        return new List<ResumoPedido>();
    }

    [HttpPost(Name = "CadastrarCliente")]
    public Cliente CadastrarCliente(string nome, string bairro)
    {
        var novoCliente = _clienteService.CadastrarCliente(nome, bairro);
        return novoCliente;
    }
}
