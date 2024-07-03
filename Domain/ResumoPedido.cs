namespace ResumoPedidos.Domain
{
    public class ResumoPedido
    {
        public int IdResumoPedido { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorTotal { get; set; }
    }
}