using System.ComponentModel.DataAnnotations;


namespace Data
{
    public class Line
    {
        [Key]
        public int LineId { get; set; }
        [Display(Name = "Linea")]
        public string LineDescription { get; set; }
    }
}
