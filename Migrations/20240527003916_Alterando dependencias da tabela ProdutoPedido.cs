using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class AlterandodependenciasdatabelaProdutoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_PEDIDO_PRODUTO_ProdutoIdProduto",
                table: "PRODUTO_PEDIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_PEDIDO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO_PEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_PEDIDO_ProdutoIdProduto",
                table: "PRODUTO_PEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_PEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO_PEDIDO");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "PRODUTO_PEDIDO");

            migrationBuilder.DropColumn(
                name: "ResumoPedidoIdResumoPedido",
                table: "PRODUTO_PEDIDO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoIdProduto",
                table: "PRODUTO_PEDIDO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResumoPedidoIdResumoPedido",
                table: "PRODUTO_PEDIDO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_PEDIDO_ProdutoIdProduto",
                table: "PRODUTO_PEDIDO",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_PEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO_PEDIDO",
                column: "ResumoPedidoIdResumoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_PEDIDO_PRODUTO_ProdutoIdProduto",
                table: "PRODUTO_PEDIDO",
                column: "ProdutoIdProduto",
                principalTable: "PRODUTO",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_PEDIDO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO_PEDIDO",
                column: "ResumoPedidoIdResumoPedido",
                principalTable: "RESUMOPEDIDO",
                principalColumn: "IdResumoPedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
