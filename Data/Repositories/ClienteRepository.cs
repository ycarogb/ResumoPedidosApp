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

        public Cliente GetCliente(int idCliente)
        {
            using var db = new ResumoPedidosContext();

            var cliente = db.Cliente.First(p => p.IdCliente == idCliente);

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
            var clienteNoBanco = db.Cliente.First(p => p.IdCliente == cliente.IdCliente);

            db.Cliente.Update(cliente);
            db.SaveChanges();
            
            return new Cliente();
        }
    }
}