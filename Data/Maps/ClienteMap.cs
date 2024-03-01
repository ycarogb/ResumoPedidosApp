using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");
            builder.HasKey(p => p.IdCliente);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Bairro).HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}