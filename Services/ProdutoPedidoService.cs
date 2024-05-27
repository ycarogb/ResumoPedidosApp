using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Data;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Services;

public class ProdutoPedidoService : IProdutoPedidoService
{
    private readonly ResumoPedidosContext _context;
    private readonly IProdutoService _produtoService;

    public ProdutoPedidoService(ResumoPedidosContext context, IProdutoService produtoService)
    {
        _context = context;
        _produtoService = produtoService;
    }

    public async Task<List<Produto>> ObterProdutosPorResumoPedidoAsync(int idResumoPedido)
    {
        var idsProdutoDoResumo = await _context.ProdutoPedido
            .Where(p => p.IdResumoPedido == idResumoPedido)
            .Select(p => p.IdProduto)
            .ToListAsync();

        var produtos = _produtoService.ObterProdutos(p => idsProdutoDoResumo.Contains(p.IdProduto));
        return produtos;
    }
}