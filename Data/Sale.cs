using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Unidades vendidas")]
        public int SaleUnits { get; set; }
        [Display(Name = "Fecha")]
        public string SaleDate { get; set; }
        [Display(Name = "Monto de pago")]
        public string SaleAmount { get; set; }
        [Display(Name = "Detalles")]
        public string SaleDetailst { get; set; }

        public int? DispatchId { get; set; }
        public virtual Dispatch Dispatch { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? StockId { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
