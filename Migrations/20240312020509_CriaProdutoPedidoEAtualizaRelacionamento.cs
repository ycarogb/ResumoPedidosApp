using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class CriaProdutoPedidoEAtualizaRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdProduto",
                table: "PRODUTO");

            migrationBuilder.DropForeignKey(
                name: "FK_RESUMOPEDIDO_CLIENTE_ClienteIdCliente",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RESUMOPEDIDO_IdProduto",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_RESUMOPEDIDO_ClienteIdCliente",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "RESUMOPEDIDO");

            migrationBuilder.RenameColumn(
                name: "ResumoPedidoIdProduto",
                table: "PRODUTO",
                newName: "ResumoPedidoIdResumoPedido");

            migrationBuilder.RenameColumn(
                name: "IdResumoPedido",
                table: "PRODUTO",
                newName: "ProdutoPedidoIdProdutoPedido");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUTO_ResumoPedidoIdProduto",
                table: "PRODUTO",
                newName: "IX_PRODUTO_ResumoPedidoIdResumoPedido");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "RESUMOPEDIDO",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PRODUTO_PEDIDO",
                columns: table => new
                {
                    IdProdutoPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "int", nullable: false),
                    ValorVendido = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    IdResumoPedido = table.Column<int>(type: "int", nullable: false),
                    ResumoPedidoIdResumoPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO_PEDIDO", x => x.IdProdutoPedido);
                    table.ForeignKey(
                        name: "FK_PRODUTO_PEDIDO_PRODUTO_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "PRODUTO",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_PEDIDO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                        column: x => x.ResumoPedidoIdResumoPedido,
                        principalTable: "RESUMOPEDIDO",
                        principalColumn: "IdResumoPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESUMOPEDIDO_IdCliente",
                table: "RESUMOPEDIDO",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMOPEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO",
                column: "ProdutoPedidoIdProdutoPedido");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO",
                column: "ProdutoPedidoIdProdutoPedido");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_PEDIDO_ProdutoIdProduto",
                table: "PRODUTO_PEDIDO",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_PEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO_PEDIDO",
                column: "ResumoPedidoIdResumoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO",
                column: "ProdutoPedidoIdProdutoPedido",
                principalTable: "PRODUTO_PEDIDO",
                principalColumn: "IdProdutoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO",
                column: "ResumoPedidoIdResumoPedido",
                principalTable: "RESUMOPEDIDO",
                principalColumn: "IdResumoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_RESUMOPEDIDO_CLIENTE_IdCliente",
                table: "RESUMOPEDIDO",
                column: "IdCliente",
                principalTable: "CLIENTE",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RESUMOPEDIDO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO",
                column: "ProdutoPedidoIdProdutoPedido",
                principalTable: "PRODUTO_PEDIDO",
                principalColumn: "IdProdutoPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO");

            migrationBuilder.DropForeignKey(
                name: "FK_RESUMOPEDIDO_CLIENTE_IdCliente",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropForeignKey(
                name: "FK_RESUMOPEDIDO_PRODUTO_PEDIDO_ProdutoPedidoIdProdutoPedido",
                table: "RESUMOPEDIDO");

            migrationBuilder.DropTable(
                name: "PRODUTO_PEDIDO");

            migrationBuilder.DropIndex(
                name: "IX_RESUMOPEDIDO_IdCliente",
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

            migrationBuilder.RenameColumn(
                name: "ResumoPedidoIdResumoPedido",
                table: "PRODUTO",
                newName: "ResumoPedidoIdProduto");

            migrationBuilder.RenameColumn(
                name: "ProdutoPedidoIdProdutoPedido",
                table: "PRODUTO",
                newName: "IdResumoPedido");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUTO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO",
                newName: "IX_PRODUTO_ResumoPedidoIdProduto");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "RESUMOPEDIDO",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "RESUMOPEDIDO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "RESUMOPEDIDO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RESUMOPEDIDO_IdProduto",
                table: "RESUMOPEDIDO",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMOPEDIDO_ClienteIdCliente",
                table: "RESUMOPEDIDO",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdProduto",
                table: "PRODUTO",
                column: "ResumoPedidoIdProduto",
                principalTable: "RESUMOPEDIDO",
                principalColumn: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_RESUMOPEDIDO_CLIENTE_ClienteIdCliente",
                table: "RESUMOPEDIDO",
                column: "ClienteIdCliente",
                principalTable: "CLIENTE",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
