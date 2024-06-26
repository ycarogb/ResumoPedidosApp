using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Maps;

public class ProdutoPedidoMap: IEntityTypeConfiguration<ProdutoPedido>
{
    public void Configure(EntityTypeBuilder<ProdutoPedido> builder)
    {
        builder.ToTable("PRODUTO_PEDIDO");
        builder.HasKey(p => p.IdProdutoPedido);

        builder
            .Property(p => p.IdProduto)
            .IsRequired();

        builder
            .Property(p => p.IdResumoPedido)
            .IsRequired();
    }
}