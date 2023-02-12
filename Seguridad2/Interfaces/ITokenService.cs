using Seguridad2.Models;

namespace Seguridad2.Interfaces
{
    //Declaracion de la Interface de Tokens
    public interface ITokenService
    {
        //Metodo para la Creacion de Token en la Implementación de la Interfaz
        string CreateToken(Users user);
    }
}
