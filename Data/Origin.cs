using System.ComponentModel.DataAnnotations;


namespace Data
{
    public class Origin
    {
        [Key]
        public int OriginId { get; set; }
        [Display(Name = "Origen")]
        public string OriginDescription { get; set; }
    }
}
