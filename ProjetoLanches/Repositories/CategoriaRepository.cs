using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly ProjetoLanchesContext _context;

        public CategoriaRepository(ProjetoLanchesContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
