using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }
        [Display(Name = "Descripcion")]
        public string DescriptionText { get; set; }
        [Display(Name = "Titulo de la descripcion")]
        public string DescriptionTitle { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
