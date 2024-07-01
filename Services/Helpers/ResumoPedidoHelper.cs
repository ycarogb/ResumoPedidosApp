using System.Text;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Services.Helpers;

public class ResumoPedidoHelper
{
    private readonly IProdutoService _produtoService;

    public ResumoPedidoHelper(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public async Task<string> CriaTextoAsync(Cliente cliente, ResumoPedido resumoPedido, List<Produto> produtos)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("----- RESUMO PEDIDO -----");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"Cliente: {cliente.Nome}");
        await AppendItensAsync(stringBuilder, produtos, resumoPedido.IdResumoPedido);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"VALOR TOTAL: {resumoPedido.ValorTotal}");

        var texto = stringBuilder.ToString();
        return texto;
    }

    private async Task AppendItensAsync(StringBuilder stringBuilder, List<Produto> produtos, int idResumoPedido)
    {
        var idsProdutosDoPedido = new List<int>(); 
        stringBuilder.AppendLine("Itens: ");
        foreach (var produto in produtos.Where(produto => !idsProdutosDoPedido.Contains(produto.IdProduto)))
        {
            var quantidadeNoPedido = await _produtoService.ObterQuantidadePorResumoPedidoAsync(idResumoPedido, produto.IdProduto);
            stringBuilder.AppendLine($"{produto.Descricao} -- Quantidade: {quantidadeNoPedido}");
            idsProdutosDoPedido.Add(produto.IdProduto);
        }
    }
}