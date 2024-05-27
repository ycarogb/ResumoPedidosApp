using ResumoPedidos.Domain;
using ResumoPedidos.Domain.Dtos;

namespace ResumoPedidos.Services.Mappers;

public static class ProdutoResumoPedidoDtoMapper
{
    public static List<ProdutoResumoPedidoDto> Map(List<Produto> produtos)
    {
        var result = new List<ProdutoResumoPedidoDto>();

        foreach (var produto in produtos)
        {
            var produtoResumoPedido = new ProdutoResumoPedidoDto();

            produtoResumoPedido.Descricao = produto.Descricao;
            produtoResumoPedido.Valor = produto.Valor;
            
            result.Add(produtoResumoPedido);
        }

        return result;
    }
}