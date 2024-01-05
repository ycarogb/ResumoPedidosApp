using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
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
}