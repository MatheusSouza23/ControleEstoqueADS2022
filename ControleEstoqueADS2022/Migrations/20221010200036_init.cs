using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoqueADS2022.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    preço = table.Column<float>(type: "real", nullable: false),
                    Fornecedorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_Fornecedorid",
                        column: x => x.Fornecedorid,
                        principalTable: "Fornecedor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: false),
                    produtoid = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<float>(type: "real", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.id);
                    table.ForeignKey(
                        name: "FK_Compra_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_clienteid",
                table: "Compra",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_produtoid",
                table: "Compra",
                column: "produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Fornecedorid",
                table: "Produto",
                column: "Fornecedorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
