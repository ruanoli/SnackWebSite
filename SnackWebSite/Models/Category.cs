using System.ComponentModel.DataAnnotations;

namespace SnackWebSite.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100,ErrorMessage ="Tamanho máximo de 100 caracteres.")]
        [Display(Name= "Nome")]
        public string? Name { get; set; }
        [StringLength(100, ErrorMessage = "Tamanho máximo de 300 caracteres.")]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        public List<Snack>? Snacks { get; set; }
    }
}
