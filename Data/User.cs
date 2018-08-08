using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Contacto")]
        public int Contact { get; set; }
        [Display(Name = "Contacto2")]
        public int Contact2 { get; set; }
        [Display(Name = "Calle")]
        public string AddressStreet { get; set; }
        [Display(Name = "Numero")]
        public int AddressNumber { get; set; }
        [Display(Name = "Departamento")]
        public int AddressDepartment { get; set; }
        [Display(Name = "Piso")]
        public string AddressFlat { get; set; }
        [Display(Name = "Localidad")]
        public string City { get; set; }
        [Display(Name = "Provincia")]
        public string Province { get; set; }
    }
}
