
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Display(Name = "Nombre")]
        public string ClientName { get; set; }
        [Display(Name = "Apellido")]
        public string ClientLastName { get; set; }
        [Display(Name = "Descripcion adicional")]
        public string SendAdditionalDescription { get; set; }
        [Display(Name = "DNI")]
        public int DNI { get; set; }
        [Display(Name = "Contacto")]
        public int Contact { get; set; }
        [Display(Name = "Contacto2")]
        public int? Contact2 { get; set; }
        [Display(Name = "Calle")]
        public string AddressStreet { get; set; }
        [Display(Name = "Numero")]
        public int? AddressNumber { get; set; }
        [Display(Name = "Departamento")]
        public int? AddressDepartment { get; set; }
        [Display(Name = "Piso")]
        public string AddressFlat { get; set; }
        [Display(Name = "Localidad")]
        public string City { get; set; }
        [Display(Name = "Provincia")]
        public string Province { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
