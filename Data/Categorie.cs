using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        [Display(Name = "Categoria")]
        public string CategorieDescription { get; set; }
    }
}
