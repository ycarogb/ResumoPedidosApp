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
              aqui temos uma relação de um para muitos nao obrigatorio, sem navegação na entidade principal, 
              onde o cliente pode estar OU NÃO associado a varios resumos pedidos
             */
            builder
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.IdCliente);
        }
    }
}