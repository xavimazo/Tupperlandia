using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        [Display(Name = "Peso")]
        public decimal? Weight { get; set; }
        [Display(Name = "Largo")]
        public decimal? Lenght { get; set; }
        [Display(Name = "Ancho")]
        public decimal? Width { get; set; }
        [Display(Name = "Altura")]
        public decimal? Height { get; set; }
        [Display(Name = "Diametro")]
        public decimal? Diameter { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Imagen URL")]
        public string Image { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
        public int? CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }
        public int? LineId { get; set; }
        public virtual Line Line { get; set; }
        public int? StockStatusId { get; set; }
        public virtual StockStatus StockStatus { get; set; }
        public int? CapacityId { get; set; }
        public virtual Capacity Capacity { get; set; }
        public int? ColorId { get; set; }
        public virtual Color Color { get; set; }
        public int? OriginId { get; set; }
        public virtual Origin Origin { get; set; }
    }
}
