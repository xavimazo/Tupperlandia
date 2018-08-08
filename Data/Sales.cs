using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Sales
    {
        [Display(Name = "Unidades vendidas")]
        public int SaleUnits { get; set; }
        [Display(Name = "Fecha")]
        public string SaleDate { get; set; }
        [Display(Name = "Monto de pago")]
        public string SaleAmount { get; set; }
        [Display(Name = "Detalles")]
        public string SaleDetailst { get; set; }
    }
}