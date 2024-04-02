using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    public Produto GetProduto(Func<Produto, bool> predicate)
    {
        using var db = new ResumoPedidosContext();

        var produto = db.Produto.First(predicate);

        return produto;
    }

    public List<Produto> GetAllProdutos()
    {
        using var db = new ResumoPedidosContext();

        var query =
            from produto in db.Produto
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

        using var db = new ResumoPedidosContext();
        db.Add(produto);
        db.SaveChanges();

        return produto;
    }

    public Produto UpdateProduto(Produto produto)
    {
        using var db = new ResumoPedidosContext();
        
        var produtoNoBanco = db.Produto.AsNoTracking().FirstOrDefault(p => p.IdProduto == produto.IdProduto);
            
        if (produtoNoBanco == null) 
            throw new Exception("Produto não encontrado");
            
        db.Produto.Update(produto);
        db.SaveChanges();
            
        var produtoComNovosDados = db.Produto.First(p => p.IdProduto == produto.IdProduto);

        return produtoComNovosDados;
    }

    public bool RemoveProduto(int idProduto)
    {
        using var db = new ResumoPedidosContext();
        
        var produtoNoBanco = db.Produto.AsNoTracking().FirstOrDefault(p => p.IdProduto == idProduto);
        //TODO: INCLUIR EXCEÇÃO TRATADA PARA ESSE CASO
        if (produtoNoBanco == null)
            return false;

        db.Produto.Remove(produtoNoBanco);
        db.SaveChanges();
        return true;
    }
}
