using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductDescription
    {
        [Key]
        public int ProductDescriptionId { get; set; }
        [Display(Name = "Descripcion de producto")]
        public string PDescription { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
