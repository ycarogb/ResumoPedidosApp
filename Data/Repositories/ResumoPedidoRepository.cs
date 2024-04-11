using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Data.Repositories;

public class ResumoPedidoRepository : IResumoPedidoRepository
{
    private readonly IClienteRepository _clienteRepository;
    private readonly ResumoPedidosContext _context;

    public ResumoPedidoRepository(IClienteRepository clienteRepository, ResumoPedidosContext context)
    {
        _clienteRepository = clienteRepository;
        _context = context;
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

    public ResumoPedido GetResumoPedido(Func<ResumoPedido, bool> predicate)
    {
        var resumoPedido = _context.ResumoPedidos.First(predicate);

        return resumoPedido;
    }

    public List<ResumoPedido> GetAllResumoPedidos()
    {
        var consultaPorSintaxe =
            from resumoPedido in _context.ResumoPedidos
            where resumoPedido.IdResumoPedido > 0
            select resumoPedido;

        return consultaPorSintaxe.ToList();
    }

    public ResumoPedido UpdateResumoPedido(ResumoPedido resumoPedido)
    {
        var resumoPedidoNoBanco = _context.ResumoPedidos
            .AsNoTracking()
            .FirstOrDefault(p => p.IdResumoPedido == resumoPedido.IdResumoPedido);
            
        if (resumoPedidoNoBanco == null) 
            throw new Exception("ResumoPedido não encontrado");
            
        _context.ResumoPedidos.Update(resumoPedido);
        _context.SaveChanges();
            
        var resumoPedidoComNovosDados = _context.ResumoPedidos.First(p => p.IdResumoPedido == resumoPedido.IdResumoPedido);

        return resumoPedidoComNovosDados;
    }

    public bool RemoveResumoPedido(int idResumoPedido)
    {
        var resumoPedidoNoBanco = _context.ResumoPedidos.AsNoTracking().FirstOrDefault(p => p.IdResumoPedido == idResumoPedido);

        if (resumoPedidoNoBanco == null) throw new Exception("Decisão não encontrada");
            
        _context.ResumoPedidos.Remove(resumoPedidoNoBanco);
        _context.SaveChanges();
        return true;
    }
}