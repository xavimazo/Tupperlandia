using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PublicationStatus
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Estado")]
        public string Status { get; set; }
    }
}
