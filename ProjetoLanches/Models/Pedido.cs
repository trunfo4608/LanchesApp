using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLanches.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Sobrenome obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Sobrenome")]
        public string SobreNome { get; set; }


        [Required(ErrorMessage = "Endereço obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Endereco1 { get; set; }


        [Required(ErrorMessage = "Complemento obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Cep obrigatório.")]
        [StringLength(10)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }


        [Required(ErrorMessage = "Estado obrigatório.")]
        [StringLength(15)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Cidade obrigatório.")]
        [StringLength(50)]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "Telefone obrigatório.")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Email obrigatório.")]
        [StringLength(100)]
        [EmailAddress]     
        public string Email { get; set; }


        [ScaffoldColumn(false)]
        [Column(TypeName ="decimal(10,2)")]
        [Display(Name ="Total pedido")]
        public decimal PedidoTotal { get; set; }


        [ScaffoldColumn(false)]
        [Display(Name = "Itens pedido")]
        public int TotalItensPedido { get; set; }

        [Display(Name ="Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy hh:mm", ApplyFormatInEditMode =true)]
        public DateTime PedidoEnviado { get; set; }


        [Display(Name = "Data Envio do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm", ApplyFormatInEditMode = true)]
        public DateTime PedidoEntregueEm { get; set; }

        public List<PedidoDetalhe> PedidoItens { get; set; }
    }
}
