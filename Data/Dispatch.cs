using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Dispatch
    {
        [Key]
        public int DispatchId { get; set; }
        [Display(Name = "Porcentaje de descuento")]
        public string DispatchDescription { get; set; }
    }
}
