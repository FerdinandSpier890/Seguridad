using System.ComponentModel.DataAnnotations;

namespace Seguridad2.Dto
{
    public class LoginDto
    {
        //Propiedad del Nombre de Usuario
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
