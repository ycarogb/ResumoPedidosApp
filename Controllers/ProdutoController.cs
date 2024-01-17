using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("[produto]")]
public class ProdutoController : ControllerBase
{
    private readonly ILogger<ProdutoController> _logger;
    private readonly ProdutoService _produtoService;

    public ProdutoController(
        ILogger<ProdutoController> logger,
        ProdutoService produtoService)
    {
        _logger = logger;
        _produtoService = produtoService;
    }

    [HttpGet(Name = "GetProduto")]
    public IEnumerable<Produto> Get()
    {
        return new List<Produto>();
    }

    [HttpPost(Name = "CadastrarProduto")]
    public Produto CadastrarProduto(string descricao, decimal valor)
    {
        var novoProduto = _produtoService.CadastrarProduto(descricao, valor);
        return novoProduto;
    }
}
