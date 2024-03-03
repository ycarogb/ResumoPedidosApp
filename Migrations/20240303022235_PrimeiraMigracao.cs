using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "RESUMOPEDIDO",
                columns: table => new
                {
                    IdResumoPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "INT", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUMOPEDIDO", x => x.IdResumoPedido);
                    table.UniqueConstraint("AK_RESUMOPEDIDO_IdProduto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_RESUMOPEDIDO_CLIENTE_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    IdResumoPedido = table.Column<int>(type: "int", nullable: true),
                    ResumoPedidoIdProduto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdProduto",
                        column: x => x.ResumoPedidoIdProduto,
                        principalTable: "RESUMOPEDIDO",
                        principalColumn: "IdProduto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ResumoPedidoIdProduto",
                table: "PRODUTO",
                column: "ResumoPedidoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMOPEDIDO_ClienteIdCliente",
                table: "RESUMOPEDIDO",
                column: "ClienteIdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "RESUMOPEDIDO");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
