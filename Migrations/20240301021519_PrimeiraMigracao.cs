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
                    IdResumoPedido = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "INT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUMOPEDIDO", x => x.IdResumoPedido);
                    table.ForeignKey(
                        name: "FK_RESUMOPEDIDO_CLIENTE_IdResumoPedido",
                        column: x => x.IdResumoPedido,
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
                    ResumoPedidoIdResumoPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoIdResumoPedido",
                        column: x => x.ResumoPedidoIdResumoPedido,
                        principalTable: "RESUMOPEDIDO",
                        principalColumn: "IdResumoPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ResumoPedidoIdResumoPedido",
                table: "PRODUTO",
                column: "ResumoPedidoIdResumoPedido");
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
