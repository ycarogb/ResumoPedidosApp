using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories;

public class ResumoPedidoRepository : IResumoPedidoRepository
{
    public ResumoPedido CreateResumoPedido(int idCliente, List<Produto> produtos, decimal valorTotal)
    {
        var resumoPedido = new ResumoPedido()
        {
            IdCliente = idCliente,
            Produtos = produtos,
            ValorTotal = valorTotal            
        };

        using var db = new ResumoPedidosContext();
        db.Add(resumoPedido);
        db.SaveChanges();

        return resumoPedido;
    }
}