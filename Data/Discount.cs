using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        [Display(Name = "Porcentaje de descuento")]
        public int? DiscountPercentage { get; set; }
    }
}
