using ResumoPedidos.Domain.Administracao;

namespace ResumoPedidos.Data.Repositories;

public class UsuarioRepository
{
    public static Usuario Get(string username, string password)
    {
        var users = new List<Usuario>()
        {
            new() { Id = 1, Username = "ladygaga", Password = "ladygaga", Role = "Dona" },
            new() { Id = 1, Username = "katyperry", Password = "katyperry", Role = "Empregada" }
        };

        var result =users.FirstOrDefault(u => 
            string.Equals(u.Username, username, StringComparison.CurrentCultureIgnoreCase) && 
            u.Password == password);
        
        return result;
    }
}