using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ResumoPedidosContext _context;

    public ProdutoRepository(ResumoPedidosContext context)
    {
        _context = context;
    }

    public Produto GetProduto(Func<Produto, bool> predicate)
    {
        var produto = _context.Produto.First(predicate);

        return produto;
    }
    
    public List<Produto> GetProdutos(Func<Produto, bool> predicate)
    {
        var produto = _context.Produto.Where(predicate).ToList();

        return produto;
    }

    public List<Produto> GetAllProdutos()
    {
        var query =
            from produto in _context.Produto
            where produto.IdProduto > 0
            select produto;

        return query.ToList();
    }

    public Produto CreateProduto(string descricao, decimal valor)
    {
        var produto = new Produto()
        {
            Descricao = descricao,
            Valor = valor
        };
        
        _context.Add(produto);
        _context.SaveChanges();

        return produto;
    }

    public Produto UpdateProduto(Produto produto)
    {
        var produtoNoBanco = _context.Produto.AsNoTracking().FirstOrDefault(p => p.IdProduto == produto.IdProduto);
            
        if (produtoNoBanco == null) 
            throw new Exception("Produto não encontrado");
            
        _context.Produto.Update(produto);
        _context.SaveChanges();
            
        var produtoComNovosDados = _context.Produto.First(p => p.IdProduto == produto.IdProduto);

        return produtoComNovosDados;
    }

    public bool RemoveProduto(int idProduto)
    {
        var produtoNoBanco = _context.Produto.AsNoTracking().FirstOrDefault(p => p.IdProduto == idProduto);
        if (produtoNoBanco == null) throw new Exception("Produto não encontrado");

        _context.Produto.Remove(produtoNoBanco);
        _context.SaveChanges();
        return true;
    }
}
