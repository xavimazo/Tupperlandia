using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Nombre")]
        public string ProductName { get; set; }
        [Display(Name = "Compuesto por")]
        public string ProductComposition { get; set; }
        [Display(Name = "Descripcion general")]
        public string FullDescription { get; set; }
        [Display(Name = "Descripcion rápida")]
        public string ShortDescription { get; set; }
        [Display(Name = "Recomendaciones")]
        public string Recomendations { get; set; }

        public virtual ICollection<Stock> Stock { get; set; }
        public virtual ICollection<ProductDescription> ProductDescription { get; set; }
    }
}
