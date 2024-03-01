namespace ResumoPedidos.Domain
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        
        public int? IdResumoPedido { get; set; }
        public ResumoPedido? ResumoPedido { get; set; }
    }
} 