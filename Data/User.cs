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
    }
}
