using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class StockStatus
    {
        [Key]
        public int StockStatusId { get; set; }
        [Display(Name = "Descripcion estado de producto")]
        public string StockStatusDescription { get; set; }
    }
}
