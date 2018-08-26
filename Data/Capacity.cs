using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Capacity
    { 
        [Key]
        public int CapacityId { get; set; }
        [Display(Name = "Capacidad")]
        public string CapacityDescription { get; set; }
    }
}
