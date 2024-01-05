namespace ResumoPedidos.Domain
{
    public class ResumoPedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public List<Produto> Produtos { get; set;}
        public decimal ValorTotal { get; set; }
    }
}