using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Capacidad")]
        public string Capacidad { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; }
        [Display(Name = "Dimensiones")]
        public string Measurements { get; set; }
        [Display(Name = "Categoria")]
        public string Categorie { get; set; }
        [Display(Name = "Linea")]
        public string Line { get; set; }
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        [Display(Name = "Stock")]
        public int CantidadStock { get; set; }
        [Display(Name = "Imagen URL")]
        public string Image { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? StatusId { get; set; }
        public virtual PublicationStatus Status { get; set; }
        public int? DiscountId { get; set; }
        public virtual Discount percentage { get; set;}
    }
}
