using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoLanches.Models;

#nullable disable

namespace ProjetoLanches.Migrations
{
    public partial class PopulaTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into categorias values('normal','lanche feito com ingredientes normais')");
            migrationBuilder.Sql("insert into categorias values('natural','lanche feito com ingredientes naturais')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from categiras");
        }
    }
}
