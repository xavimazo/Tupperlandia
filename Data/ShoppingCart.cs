using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        [Display(Name = "Unidades vendidas")]
        public int Amount { get; set; }
        [Display(Name = "Fecha")]
        public string CartDate { get; set; }

        public ICollection<Stock> Stock { get; set; }

        public int? DispatchId { get; set; }
        public virtual Dispatch Dispatch { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
