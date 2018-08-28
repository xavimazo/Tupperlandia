using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Color
    { 
        [Key]
        public int ColorId { get; set; }
        [Display(Name = "Color")]
        public string ColorDescription { get; set; }
    }
}
