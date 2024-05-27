using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class AlteradependenciasdatabelaProdutoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO");

            migrationBuilder.DropForeignKey(
                name: "FK_RESUMOPEDIDO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_RESUMOPEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropColumn(
                name: "ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RESUMOPEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO",
                column: "ProdutoPedidoIdProdutoPedido");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO",
                column: "ProdutoPedidoIdProdutoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO",
                column: "ProdutoPedidoIdProdutoPedido",
                principalTable: "PRODUTO_PEDIDO",
                principalColumn: "IdProdutoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_RESUMOPEDIDO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO",
                column: "ProdutoPedidoIdProdutoPedido",
                principalTable: "PRODUTO_PEDIDO",
                principalColumn: "IdProdutoPedido");
        }
    }
}
