using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ResumoPedidosContext _context;

        public ClienteRepository(ResumoPedidosContext context)
        {
            _context = context;
        }

        public List<Cliente> GetAllClientes()
        {
            var consultaPorSintaxe =
                from cliente in _context.Cliente
                where cliente.IdCliente > 0
                select cliente;

            return consultaPorSintaxe.ToList();
        }

        public Cliente GetCliente(Func<Cliente, bool> predicate)
        {
            var cliente = _context.Cliente.First(predicate);

            return cliente;
        }

        public Cliente CreateCliente(string nome, string bairro)
        {
            var cliente = new Cliente()
            {
                Nome = nome,
                Bairro = bairro
            };
            
            _context.Add(cliente);
            //.SaveChanges() persiste no banco de dados os registros incluídos ou alterados
            _context.SaveChanges();

            return cliente;
        }

        /*
            O método .AddRange() Serve para coleção de objetos com mesmo tipo ou para inserir objetos com tipos diferentes
         */
        public List<Cliente> CreateClientes(List<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                CreateCliente(cliente.Nome, cliente.Bairro);
                clientes.Add(cliente);
            }
            _context.AddRange(clientes);
            _context.SaveChanges();

            return clientes;

        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            /*
             * Uso do .AsNoTracking para que o EF não rastreie as informações dos registros nesta consulta e evite conflitos ao
             * editar os dados. Adotei essa solução pois aqui só queremos saber se os registros exitem e não seus valores! 
             */
            var clienteNoBanco = _context.Cliente.AsNoTracking().FirstOrDefault(p => p.IdCliente == cliente.IdCliente);
            
            if (clienteNoBanco == null) 
                throw new Exception("Cliente não encontrado");
            
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
            
            var clienteComNovosDados = _context.Cliente.First(p => p.IdCliente == cliente.IdCliente);

            return clienteComNovosDados;
        }

        public bool RemoveCliente(int idCliente)
        {
            var clienteNoBanco = _context.Cliente.AsNoTracking().FirstOrDefault(p => p.IdCliente == idCliente);

            if (clienteNoBanco == null) throw new Exception("Decisão não encontrada");
            
            _context.Cliente.Remove(clienteNoBanco);
            _context.SaveChanges();
            return true;
        }
    }
}
