using ProjetoLanches.Models;

namespace ProjetoLanches.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}
