using Microsoft.IdentityModel.Tokens;
using Seguridad2.Interfaces;
using Seguridad2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Seguridad2.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey key;

        //Constructor de la Clase Token
        public TokenService(IConfiguration configuration)
        {
            //Obtención de la Clave Simetrica
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        /*
         * Metodo que se encarga de crear un token para acceder a una aplicación
         */
        public string CreateToken(Users user)
        {
            var claims = new List<Claim>();

            //Objeto que contiene información del token creado
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Se agrega el nombre del identificador del token en este caso el nombre del usuario
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credenciales,
            };

            //Generamos el marcador del token de seguridad
            var tokenHandler = new JwtSecurityTokenHandler();

            //Creamos el jwtToken con la descirpción del token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
