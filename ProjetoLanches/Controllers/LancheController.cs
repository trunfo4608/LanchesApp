﻿using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Models;
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
        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {  
                    lanches = _lancheRepository.Lanches      
                                .Where(l => l.Categoria.CategoriaNome == categoria)
                                .OrderBy(l => l.Nome);
             }

            categoriaAtual = categoria;

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            ViewData["DataHora"] = DateTime.Now;

            var totalLanches = lanches.Count();

            ViewBag.totalLanches = totalLanches;

            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lancheDetails = _lancheRepository.Lanches.FirstOrDefault(l => l.Id == lancheId);

            return View(lancheDetails);
        }
    }
}
