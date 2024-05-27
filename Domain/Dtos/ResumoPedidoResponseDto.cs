namespace ResumoPedidos.Domain.Dtos;

public class ResumoPedidoResponseDto
{
    public string NomeCliente { get; init; }
    public List<ProdutoResumoPedidoDto> Produtos { get; init; } = new();
    public decimal ValorTotal { get; init; }
}