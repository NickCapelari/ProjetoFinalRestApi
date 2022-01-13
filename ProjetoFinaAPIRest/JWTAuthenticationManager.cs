using Microsoft.IdentityModel.Tokens;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProjetoFinaAPIRest
{

    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string tokenKey;



        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;

        }



      
        public string Authenticate(string username, string password)
        {
            UsuarioService _usuarioService = new UsuarioService();
            Usuario u = _usuarioService.FindByName(username);
            if (u.User == username && u.Password == password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(tokenKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            else { return null; }

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(tokenKey);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, username)
            //    }),
            //    Expires = DateTime.UtcNow.AddHours(1),
            //    SigningCredentials = new SigningCredentials(
            //        new SymmetricSecurityKey(key),
            //        SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
        }

    }
}
