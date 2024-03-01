using ResumoPedidos.Application.DTOs;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
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

        public Cliente UpdateCliente(ClienteUpdate clienteUpdate)
        {
            //TODO: Criar esse método
            
            //Busca o cliente no dbset
            //altera o que deve ser alterado
            //SaveChanges
            return new Cliente();
        }
    }
}