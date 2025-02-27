using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Context;

namespace ProjetoLanches.Models
{
    public class CarrinhoCompra
    {
        private readonly ProjetoLanchesContext _context;

        public CarrinhoCompra(ProjetoLanchesContext context)
        {
            _context = context;
        }

        public string Id { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }


        public static CarrinhoCompra GetCarrinho(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<ProjetoLanchesContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                Id = carrinhoId
            };
        }

        public void AdicionarCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems
                                        .SingleOrDefault(
                                          s => s.Lanche.Id == lanche.Id
                                             &&
                                             s.CarrinhoCompraId == Id
                                         );


            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = Id,
                    Lanche = lanche,
                    Qtde = 1
                };

                _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Qtde++;
            }

            _context.SaveChanges();
        }

        public void RemoverCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                    s => s.Lanche.Id == lanche.Id
                    &&
                    s.CarrinhoCompraId == Id
                );

            if(carrinhoCompraItem != null)
            {
                carrinhoCompraItem .Qtde--;
            }
            else
            {
                _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
            }

            _context.SaveChanges();
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ??
                (CarrinhoCompraItems =
                  _context.CarrinhoCompraItems
                  .Where(c => c.CarrinhoCompraId == Id)
                  .Include(s => s.Lanche)
                  .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItems
                                  .Where(c => c.CarrinhoCompraId == Id);

            _context.CarrinhoCompraItems.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }


        public decimal GetCarrinhoTotal()
        {
            var total = _context.CarrinhoCompraItems
                         .Where(c => c.CarrinhoCompraId == Id)
                         .Select(c => c.Lanche.Preco * c.Qtde).Sum();

            return total;
        }
    }
}
