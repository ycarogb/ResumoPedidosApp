using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumoPedidos.Migrations
{
    public partial class CriacaoNovaTabelaResumoPedido7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESUMOPEDIDO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "INT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUMOPEDIDO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    ResumoPedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUTO_RESUMOPEDIDO_ResumoPedidoId",
                        column: x => x.ResumoPedidoId,
                        principalTable: "RESUMOPEDIDO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ResumoPedidoId",
                table: "PRODUTO",
                column: "ResumoPedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "RESUMOPEDIDO");
        }
    }
}
