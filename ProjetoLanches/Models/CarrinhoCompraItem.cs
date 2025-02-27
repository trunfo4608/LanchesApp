using System.ComponentModel.DataAnnotations;

namespace ProjetoLanches.Models
{
    public class CarrinhoCompraItem
    {
        public int Id { get;set; }
        public Lanche Lanche { get; set; }
        public int Qtde { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
