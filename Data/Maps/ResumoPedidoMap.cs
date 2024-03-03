using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Maps
{
    public class ResumoPedidoMap : IEntityTypeConfiguration<ResumoPedido>
    {
        public void Configure(EntityTypeBuilder<ResumoPedido> builder)
        {
            builder.ToTable("RESUMOPEDIDO");
            builder.HasKey(p => p.IdResumoPedido);
            
            builder.Property(p => p.ValorTotal)
            .HasColumnType("DECIMAL(5,2)")
            .IsRequired();

            /*
              aqui temos uma relação de um para muitos nao obrigatorio, onde o cliente pode estar OU NÃO associado a varios resumos pedidos
             */
            builder
                .HasOne(p => p.Cliente)
                .WithMany(p => p.ResumoPedidos)
                .HasPrincipalKey(p => p.IdCliente);

            /*
                Relação um para muitos sem navegação para a entidade principal e com chave estrangeira de sombra
             */
            builder
                .HasMany(p => p.Produtos)
                .WithOne(p => p.ResumoPedido)
                .HasPrincipalKey(p => p.IdProduto)
                .IsRequired(false);
        }
    }
}