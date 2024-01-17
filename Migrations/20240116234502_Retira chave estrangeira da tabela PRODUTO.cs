using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class RetirachaveestrangeiradatabelaPRODUTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId",
                table: "PRODUTO");

            migrationBuilder.AlterColumn<int>(
                name: "ResumoPedidoId",
                table: "PRODUTO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId",
                table: "PRODUTO",
                column: "ResumoPedidoId",
                principalTable: "RESUMOPEDIDO",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId",
                table: "PRODUTO");

            migrationBuilder.AlterColumn<int>(
                name: "ResumoPedidoId",
                table: "PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId",
                table: "PRODUTO",
                column: "ResumoPedidoId",
                principalTable: "RESUMOPEDIDO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
