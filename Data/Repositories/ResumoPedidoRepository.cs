using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Data.Repositories;

public class ResumoPedidoRepository : IResumoPedidoRepository
{
    private IClienteRepository _clienteRepository;

    public ResumoPedidoRepository(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public ResumoPedido CreateResumoPedido(CadastrarResumoPedidoDto dto, decimal valorTotal)
    {
        var cliente = _clienteRepository.GetCliente(p => p.IdCliente == dto.IdCliente);
        var resumoPedido = new ResumoPedido()
        {
            Cliente = cliente,
            Produtos = dto.Produtos,
            ValorTotal = valorTotal            
        };

        using var db = new ResumoPedidosContext();
        db.Add(resumoPedido);
        db.SaveChanges();

        return resumoPedido;
    }
}