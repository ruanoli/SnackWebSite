using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackWebSite.Models
{
    public class Snack
    {
        public int SnackId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage ="Tamnho máximo de 100 caracteres.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")] //precisão de 10 digitos com até duas casas decimais.
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Descrição curta")]
        [StringLength(300, ErrorMessage = "Tamnho máximo de 300 caracteres.")]   
        public string? LittleDescription { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Descrição detalhada")]
        [StringLength(580, ErrorMessage = "Tamnho máximo de 500 caracteres.")]
        public string? LongDescription { get; set; }
        [Display(Name = "Url da imagem")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Imagem em miniatura")]
        public string? ImageMiniatureUrl { get; set; }
        [Display(Name = "Lanche preferido")]
        public bool IsSnackPrefer { get; set; }
        [Display(Name = "Em estoque")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
