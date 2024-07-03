using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Data.Repositories;

public class ProdutoPedidoRepository : IProdutoPedidoRepository
{
    private readonly ResumoPedidosContext _context;

    public ProdutoPedidoRepository(ResumoPedidosContext context)
    {
        _context = context;
    }

    public async Task<List<ProdutoPedido>> CreateProdutosPedidosAsync(List<ProdutoResumoPedidoDto> produtos, int idResumoPedido)
    {
        var novosRegistros = new List<ProdutoPedido>();
        
        foreach (var produto in produtos)
        {
            for (var qtde = 0; qtde < produto.Quantidade; qtde++)
            {
                var novoRegistro = new ProdutoPedido(){IdProduto = produto.IdProduto, IdResumoPedido = idResumoPedido};
                novosRegistros.Add(novoRegistro);
            }
        }
        
        await _context.AddRangeAsync(novosRegistros);
        await _context.SaveChangesAsync();

        return novosRegistros;
    }

    public async Task<int> ObterQuantidadeProdutosNoPedidoAsync(int idResumoPedido, int idProduto)
    {
        var quantidade = await _context.ProdutoPedido
            .Where(p => p.IdResumoPedido == idResumoPedido && p.IdProduto == idProduto)
            .ToListAsync();

        return quantidade.Count;
    }
}