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
        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public string Client { get; set; }
        [Display(Name = "Producto y capacidad")]
        public string ProductAndCapacity { get; set; }
        [Display(Name = "Unidades vendidas")]
        public int Units { get; set; }
        [Display(Name = "Fecha")]
        public string Date { get; set; }
    }
}
