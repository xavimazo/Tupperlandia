using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Dispatch
    {
        [Key]
        public int DispatchId { get; set; }
        [Display(Name = "Punto de retiro")]
        public string DispatchDescription { get; set; }
    }
}
