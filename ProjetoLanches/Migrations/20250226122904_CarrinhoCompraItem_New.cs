using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLanches.Migrations
{
    public partial class CarrinhoCompraItem_New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carrinhoCompraItems_Lanches_LancheId",
                table: "carrinhoCompraItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carrinhoCompraItems",
                table: "carrinhoCompraItems");

            migrationBuilder.RenameTable(
                name: "carrinhoCompraItems",
                newName: "CarrinhoCompraItems");

            migrationBuilder.RenameIndex(
                name: "IX_carrinhoCompraItems_LancheId",
                table: "CarrinhoCompraItems",
                newName: "IX_CarrinhoCompraItems_LancheId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCompraItems",
                table: "CarrinhoCompraItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItems_Lanches_LancheId",
                table: "CarrinhoCompraItems",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItems_Lanches_LancheId",
                table: "CarrinhoCompraItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCompraItems",
                table: "CarrinhoCompraItems");

            migrationBuilder.RenameTable(
                name: "CarrinhoCompraItems",
                newName: "carrinhoCompraItems");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCompraItems_LancheId",
                table: "carrinhoCompraItems",
                newName: "IX_carrinhoCompraItems_LancheId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carrinhoCompraItems",
                table: "carrinhoCompraItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_carrinhoCompraItems_Lanches_LancheId",
                table: "carrinhoCompraItems",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
