using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Valor).HasColumnType("DECIMAL(5,2)").IsRequired();
        }
    }
}