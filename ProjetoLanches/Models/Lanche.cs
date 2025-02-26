using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLanches.Models
{
    
    public class Lanche
    {
        [Key]
        public int Id { get; set; }


        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nome entre {2} e {1} caracteres.")]
        [Required(ErrorMessage = "Nome obrigatorio.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [StringLength(200, MinimumLength = 8, ErrorMessage = "Descrição entre {2} e {1} caracteres.")]
        [Required(ErrorMessage = "Descrição curta obrigatorio.")]
        [Display(Name = "Descrição curta")]
        public string DescricaoCurta { get; set; }


        [StringLength(200, MinimumLength = 20, ErrorMessage = "Descrição entre {2} e {1} caracteres.")]
        [Required(ErrorMessage = "Descrição detalhada obrigatorio.")]
        [Display(Name = "Descrição detalhada")]
        public string? DescricaoDetalhada { get; set; }


        [Column(TypeName ="decimal(10,2)")]
        [Required(ErrorMessage = "Preço obrigatorio.")]
        [Display(Name = "Preço")]
        [Range(1,999.99,ErrorMessage ="Preço entre {1} e {2}.")]
        public decimal Preco { get; set; }

        [Display(Name ="Caminho imagem normal.")]
        [StringLength(200, ErrorMessage = "{0} deve ter {1} caracteres.")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho imagem miniatura.")]
        [StringLength(200, ErrorMessage = "{0} deve ter {1} caracteres.")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name ="Preferido ?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }


        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
