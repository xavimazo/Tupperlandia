using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre del producto")]
        public string Name { get; set; }
        [Display(Name = "Compuesto por")]
        public string Composition { get; set; }
        [Display(Name = "Descripcion general")]
        public string LargeDescription { get; set; }
        [Display(Name = "Descripcion rápida")]
        public string ShortDescription { get; set; }
        [Display(Name = "Recomendaciones")]
        public string Recomendations { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
