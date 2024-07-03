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

            builder.Property(p => p.IdCliente)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}