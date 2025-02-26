using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLanches.Models
{
    
    public class Categoria
    {

        [Key]
        public int Id { get; set; }

        [StringLength(100,MinimumLength =5,ErrorMessage ="Categoria entre {2} e {1} caracteres.")]
        [Required(ErrorMessage ="Categoria obrigatorio.")]
        [Display(Name ="Nome")]
        public string? CategoriaNome { get; set; }

        [StringLength(200, MinimumLength = 8, ErrorMessage = "Descrição entre {2} e {1} caracteres.")]
        [Required(ErrorMessage = "Descrição obrigatorio.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        public List<Lanche> Lanches { get; set; }
    }
}
