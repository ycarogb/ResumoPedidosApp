using ResumoPedidos.Domain;

namespace ResumoPedidos.Services.Helpers
{
    public class CalculadoraDePrecos
    {
        public decimal ObterValorTotal(List<Produto> produtos)
        {
            if (!produtos.Any()) return 0;
            
            var result = produtos.Select(p => p.Valor).Sum();
            return result;
        }
    }
}