using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("resumopedido")]
public class ResumoPedidoController : ControllerBase
{
    private readonly ILogger<ResumoPedidoController> _logger;
    private readonly IResumoPedidoService _resumoPedidoService;

    public ResumoPedidoController(
        ILogger<ResumoPedidoController> logger,
        IResumoPedidoService resumoPedidoService)
    {
        _logger = logger;
        _resumoPedidoService = resumoPedidoService;
    }

    [HttpGet(Name = "GetResumoPedido")]
    public IEnumerable<ResumoPedido> Get()
    {
        return new List<ResumoPedido>();
    }

    [HttpPost(Name = "CadastrarResumoPedido")]
    public ResumoPedido CadastrarResumoPedido(Cliente cliente, List<Produto> produtos)
    {
        var novoResumoPedido = _resumoPedidoService.CadastrarResumoPedido(cliente, produtos);
        return novoResumoPedido;
    }
}