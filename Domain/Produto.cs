namespace ResumoPedidos.Domain
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public ResumoPedido? ResumoPedido { get; set; }
    }
} 