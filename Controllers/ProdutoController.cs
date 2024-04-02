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

    [HttpGet("GetById")]
    public Produto ObterProdutoPorId(int id)
    {
        var produto = _produtoService.ObterProduto(p => p.IdProduto == id);
        return produto;
    }

    [HttpGet("GetProdutos")]
    public List<Produto> ObterProdutos()
    {
        var produtos = _produtoService.ObterTodosOsProdutos();
        return produtos;
    }

    [HttpPost("Cadastrar")]
    public Produto Cadastrar(string descricao, decimal valor)
    {
        var novoProduto = _produtoService.CadastrarProduto(descricao, valor);
        return novoProduto;
    }

    [HttpPost("EditarDados")]
    public Produto EditarDados(Produto produto)
    {
        var produtoEditado = _produtoService.EditarDados(produto);
        return produtoEditado;
    }

    [HttpDelete("DeletarProduto")]
    public bool ExcluirProduto(int idProduto)
    {
        var produtoExcluido = _produtoService.ExcluirProduto(idProduto);
        return produtoExcluido;
    }
}
