using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public class ProdutoPedidoRepository : IProdutoPedidoRepository
{
    private readonly ResumoPedidosContext _context;

    public ProdutoPedidoRepository(ResumoPedidosContext context)
    {
        _context = context;
    }

    public async Task<List<ProdutoPedido>> CreateProdutosPedidosAsync(int[] idsProduto, int idResumoPedido)
    {
        var novosRegistros = idsProduto
            .Select(id => new ProdutoPedido() { IdProduto = id, IdResumoPedido = idResumoPedido }).ToList();

        await _context.AddRangeAsync(novosRegistros);
        await _context.SaveChangesAsync();

        return novosRegistros;
    }
}