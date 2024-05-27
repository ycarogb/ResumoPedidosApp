using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class AlteratabelaProdutoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorVendido",
                table: "PRODUTO_PEDIDO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorVendido",
                table: "PRODUTO_PEDIDO",
                type: "DECIMAL(5,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
