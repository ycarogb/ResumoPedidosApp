using ResumoPedidos.Domain;

namespace ResumoPedidos.Application.DTOs;

public class ClienteUpdate
{
    public int? IdCliente { get; set; }
    public string? Nome { get; set; }
    public string? Bairro { get; set; }
    public List<ResumoPedido>? ResumoPedidos { get; set; }
}