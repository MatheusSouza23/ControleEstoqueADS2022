using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoqueADS2022.Migrations
{
    /// <inheritdoc />
    public partial class DeleteProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Produto_produtoid",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produto_Produtoid",
                table: "Estoques");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Compra_produtoid",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "produtoid",
                table: "Compra");

            migrationBuilder.RenameColumn(
                name: "Produtoid",
                table: "Estoques",
                newName: "Fornecedorid");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_Produtoid",
                table: "Estoques",
                newName: "IX_Estoques_Fornecedorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Fornecedor_Fornecedorid",
                table: "Estoques",
                column: "Fornecedorid",
                principalTable: "Fornecedor",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Fornecedor_Fornecedorid",
                table: "Estoques");

            migrationBuilder.RenameColumn(
                name: "Fornecedorid",
                table: "Estoques",
                newName: "Produtoid");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_Fornecedorid",
                table: "Estoques",
                newName: "IX_Estoques_Produtoid");

            migrationBuilder.AddColumn<int>(
                name: "produtoid",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fornecedorid = table.Column<int>(type: "int", nullable: true),
                    dataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preço = table.Column<float>(type: "real", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Compra_produtoid",
                table: "Compra",
                column: "produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Fornecedorid",
                table: "Produto",
                column: "Fornecedorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Produto_produtoid",
                table: "Compra",
                column: "produtoid",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produto_Produtoid",
                table: "Estoques",
                column: "Produtoid",
                principalTable: "Produto",
                principalColumn: "id");
        }
    }
}
