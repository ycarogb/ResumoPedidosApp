namespace ResumoPedidos.Domain;

public class ProdutoPedido
{
    public int IdProdutoPedido { get; set; }
    public int IdProduto { get; set; }
    public Produto Produto { get; set; }
    public decimal ValorVendido { get; set; }
    public int IdResumoPedido { get; set; }
    public ResumoPedido ResumoPedido { get; set; }
}