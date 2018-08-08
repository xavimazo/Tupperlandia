using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Display(Name = "Nombre")]
        public string SendAdrress { get; set; }
        [Display(Name = "Descripcion de envio")]
        public string SendDescription { get; set; }
        [Display(Name = "DNI")]
        public int DNI { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
