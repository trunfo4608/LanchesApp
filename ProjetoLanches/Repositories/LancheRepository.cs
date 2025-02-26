using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly ProjetoLanchesContext _context;

        public LancheRepository(ProjetoLanchesContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(l => l.IsLanchePreferido).Include(l => l.Categoria);

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(l => l.Categoria);

        public Lanche GetLancheById(int id)
        {
            return _context.Lanches.FirstOrDefault(l => l.Id == id);
        }
    }
}
