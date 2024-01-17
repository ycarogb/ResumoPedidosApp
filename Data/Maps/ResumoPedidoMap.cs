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
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdCliente)
            .HasColumnType("INT")
            .IsRequired();
            
            builder.Property(p => p.ValorTotal)
            .HasColumnType("DECIMAL(5,2)")
            .IsRequired();
        }
    }
}