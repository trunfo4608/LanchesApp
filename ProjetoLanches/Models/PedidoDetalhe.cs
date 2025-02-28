using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLanches.Models
{
    public class PedidoDetalhe
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int LancheId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        public virtual Lanche Lanche { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
