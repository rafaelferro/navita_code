using Ex_Navita_DB;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ex_Navita_2.Service
{
    public static class JwtClass
    {
        public static string token(Usuario usuario)
        {
            var token = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(SecretClass.secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.nome),
                    new Claim(ClaimTypes.Role, usuario.email)

                }),
                Expires = DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)

            };

            var t = token.CreateToken(tokenDescriptor);


            return token.WriteToken(t);
        }

    }
}
