using AppCompletoApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppCompletoApi.Static
{
    public static class JwtUtil
    {
        public static string GerarToken(Usuario u)
        {
            //#tirar
            // Em produção guardar isso com segurança, não deixar direto assim
            string chaveAssinatura = "bfe3r98095y4ndkjnwpii3r873bcfwuegfaaa";
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(chaveAssinatura);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                algorithm: SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GerarClaims(u),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(4)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GerarClaims(Usuario u) { 
        
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(type: ClaimTypes.Email, value: u.Email));
            ci.AddClaim(new Claim(type: "Id", value: u.Id.ToString()));
            ci.AddClaim(new Claim(type: ClaimTypes.Name, value: u.Nome));
            ci.AddClaim(new Claim(type: ClaimTypes.Gender, value: u.Sexo));
            ci.AddClaim(new Claim(type: ClaimTypes.Role, value: u.TipoUsuario.Titulo));

            return ci;
        }
    }
}
