using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string NombreDelCliente { get; set; }
        [Display(Name = "Calle")]
        public string Calle { get; set; }
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }
        [Display(Name = "Numeracion")]
        public int Numeracion { get; set; }
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
        [Display(Name = "Piso")]
        public int Piso { get; set; }
        [Display(Name = "Contacto")]
        public int ContactoCliente { get; set; }
        [Display(Name = "Email")]
        public string EmailCliente { get; set; }
        [Display(Name = "Social")]
        public string SocialClient { get; set; }
        [Display(Name = "Detalles de domicilio")]
        public string ResidencyDetail { get; set; }
    }
}
