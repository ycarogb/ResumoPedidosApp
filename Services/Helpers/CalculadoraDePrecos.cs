using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Services.Helpers
{
    public class CalculadoraDePrecos
    {
        public decimal ObterValorTotal(List<Produto> produtosBanco, CadastrarResumoPedidoDto dto)
        {
            if (!produtosBanco.Any()) return 0;

            var valorTotal = (from produto in dto.Produtos 
                let valorProduto = produtosBanco.First(p => p.IdProduto == produto.IdProduto).Valor 
                select valorProduto * produto.Quantidade).Sum();

            return valorTotal;
        }
    }
}