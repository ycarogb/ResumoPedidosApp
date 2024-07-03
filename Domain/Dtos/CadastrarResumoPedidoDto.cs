namespace ResumoPedidos.Domain.Dtos;

public class CadastrarResumoPedidoDto
{
    public int IdCliente { get; set; }
    public List<ProdutoResumoPedidoDto> Produtos { get; set; }
}