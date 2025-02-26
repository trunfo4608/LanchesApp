using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Models.ViewModels;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }
        public IActionResult List()
        {
            ViewData["DataHora"] = DateTime.Now;

            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;

            var totalLanches = lancheListViewModel.Lanches.Count();

            ViewBag.totalLanches = totalLanches;

            return View(lancheListViewModel);
        }
    }
}
