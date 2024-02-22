using Microsoft.AspNetCore.Mvc;
using ResumoPedidos.Domain;
using ResumoPedidos.Services;

namespace ResumoPedidos.Controllers;

[ApiController]
[Route("produto")]
public class ProdutoController : ControllerBase
{
    private readonly ILogger<ProdutoController> _logger;
    private readonly IProdutoService _produtoService;

    public ProdutoController(
        ILogger<ProdutoController> logger,
        IProdutoService produtoService)
    {
        _logger = logger;
        _produtoService = produtoService;
    }

    [HttpGet(Name = "GetProdutos")]
    public IEnumerable<Produto> ObterProdutos()
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