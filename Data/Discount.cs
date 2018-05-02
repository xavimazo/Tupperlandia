using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Porcentaje de descuento")]
        public string percentage { get; set; }
    }
}
