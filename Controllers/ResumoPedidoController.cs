using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("resumopedido")]
public class ResumoPedidoController : ControllerBase
{
    private readonly ILogger<ResumoPedidoController> _logger;
    private readonly IResumoPedidoService _service;

    public ResumoPedidoController(
        ILogger<ResumoPedidoController> logger,
        IResumoPedidoService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetById")]
    public ResumoPedido ObterResumoPedidoPorId(int id)
    {
        var resumoPedido = _service.ObterResumoPedido(p => p.IdResumoPedido == id);
        return resumoPedido;
    }
    
    [HttpGet(Name = "GetResumosPedidos")]
    public IEnumerable<ResumoPedido> Get()
    {
        var resumosPedidos = _service.ObterTodosOsResumoPedidos();
        return resumosPedidos;
    }

    [HttpPost(Name = "CadastrarResumoPedido")]
    public async Task<ResumoPedidoResponseDto> CadastrarResumoPedido(CadastrarResumoPedidoDto dto)
    {
        var novoResumoPedido = await _service.CadastrarResumoPedidoAsync(dto);
        return novoResumoPedido;
    }
    
    [HttpPost("EditarDados")]
    public ResumoPedido EditarDados(ResumoPedido resumoPedido)
    {
        var resumoPedidoEditado = _service.EditarDados(resumoPedido);
        return resumoPedidoEditado;
    }

    [HttpDelete("DeletarResumoPedido")]
    public bool ExcluirResumoPedido(ResumoPedido resumoPedido)
    {
        var resumoPedidoExcluido = _service.ExcluirResumoPedido(resumoPedido.IdResumoPedido);
        return resumoPedidoExcluido;
    }
}