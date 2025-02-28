using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        
        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItemsPedidos = 0;
            decimal precoTotalPedido = 0.0m;

            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = items;

            if(_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, que tal incluir um lanche...");
            }

            foreach (var item in items)
            {
                totalItemsPedidos += item.Qtde;
                precoTotalPedido += (item.Lanche.Preco * item.Qtde);
            }

            pedido.TotalItensPedido = totalItemsPedidos;
            pedido.PedidoTotal = precoTotalPedido;

            if (!ModelState.IsValid) 
            {
                _pedidoRepository.CriarPedido(pedido);

                ViewBag.checkOutMsg = "Pedido feito com sucesso !";
                ViewBag.totalPedido = _carrinhoCompra.GetCarrinhoTotal();

                _carrinhoCompra.LimparCarrinho();

                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);      

        }


    }
}
