using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ProjetoLanchesContext _context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(ProjetoLanchesContext context, CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();


            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach (var item in carrinhoCompraItens)
            {
                var pedidoDetails = new PedidoDetalhe()
                {
                    Quantidade = item.Qtde,
                    LancheId = item.Lanche.Id,
                    PedidoId = pedido.Id,
                    Preco = item.Lanche.Preco
                };

                _context.PedidoDetalhes.Add(pedidoDetails);

                _context.SaveChanges();
            }
        }
    }
}
