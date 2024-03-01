using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class AtualizaRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "ResumoPedidoIdResumoPedido",
                table: "PRODUTO");

            migrationBuilder.AddColumn<int>(
                name: "IdResumoPedido",
                table: "PRODUTO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_IdResumoPedido",
                table: "PRODUTO",
                column: "IdResumoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_IdResumoPedido",
                table: "PRODUTO",
                column: "IdResumoPedido",
                principalTable: "RESUMOPEDIDO",
                principalColumn: "IdResumoPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_IdResumoPedido",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_IdResumoPedido",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "IdResumoPedido",
                table: "PRODUTO");

            migrationBuilder.AddColumn<int>(
                name: "ResumoPedidoIdResumoPedido",
                table: "PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO",
                column: "ResumoPedidoIdResumoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO",
                column: "ResumoPedidoIdResumoPedido",
                principalTable: "RESUMOPEDIDO",
                principalColumn: "IdResumoPedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
