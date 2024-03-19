using Microsoft.EntityFrameworkCore;
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
                from cliente in db.Cliente
                where cliente.IdCliente > 0
                select cliente;

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
            /*
             * Uso do .AsNoTracking para que o EF não rastreie as informações dos registros nesta consulta e evite conflitos ao
             * editar os dados. Adotei essa solução pois aqui só queremos saber se os registros exitem e não seus valores! 
             */
            var clienteNoBanco = db.Cliente.AsNoTracking().FirstOrDefault(p => p.IdCliente == cliente.IdCliente);
            
            if (clienteNoBanco == null) 
                throw new Exception("Cliente não encontrado");
            
            db.Cliente.Update(cliente);
            db.SaveChanges();
            
            var clienteComNovosDados = db.Cliente.First(p => p.IdCliente == cliente.IdCliente);

            return clienteComNovosDados;
        }
    }
}