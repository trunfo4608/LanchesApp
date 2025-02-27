using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Models;

namespace ProjetoLanches.Context
{
    public class ProjetoLanchesContext : DbContext
    {
        public ProjetoLanchesContext(DbContextOptions<ProjetoLanchesContext> context)
            :base(context)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

    }



}
