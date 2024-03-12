using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //TODO: Considerar usar outra forma de injetar o context para melhorar "testabilidade"
        public List<Cliente> GetAllClientes()
        {
            using var db = new ResumoPedidosContext();

            var consultaPorSintaxe =
                from c in db.Cliente
                where c.IdCliente > 0
                select c;
            var consultaPorMetodo = db.Cliente.Where(p => p.IdCliente > 0).ToList();

            return consultaPorSintaxe.ToList();
        }

        public Cliente GetCliente(Func<Cliente, bool> predicate)
        {
            using var db = new ResumoPedidosContext();

            var cliente = db.Cliente.First(predicate);

            return cliente;
        }

        public Cliente CreateCliente(string nome, string bairro)
        {
            var cliente = new Cliente()
            {
                Nome = nome,
                Bairro = bairro
            };

            using var db = new ResumoPedidosContext();
            db.Add(cliente);
            //.SaveChanges() persiste no banco de dados os registros incluídos ou alterados
            db.SaveChanges();

            return cliente;
        }

        /*
            O método .AddRange() Serve para coleção de objetos com mesmo tipo ou para inserir objetos com tipos diferentes
         */
        public static void CreateClientes(List<Cliente> clientes)
        {
            using var db = new ResumoPedidosContext();
            db.AddRange(clientes);

            var registros = db.SaveChanges();
            Console.WriteLine($"foram afetados {registros}");
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            using var db = new ResumoPedidosContext();
            // var clienteNoBanco = db.Cliente.FirstOrDefault(p => p.IdCliente == cliente.IdCliente);
            //
            // if (clienteNoBanco == null) 
            //     throw new Exception("Cliente não encontrado");
            
            db.Cliente.Update(cliente);
            db.SaveChanges();
            
            var clienteComNovosDados = db.Cliente.First(p => p.IdCliente == cliente.IdCliente);

            return clienteComNovosDados;
        }
    }
}