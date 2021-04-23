using Dominio.Interfaces.Servicos.Autenticacao;
using Microsoft.IdentityModel.Tokens;
using prmToolkit.NotificationPattern;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Dominio.Servicos.Autenticacao
{
    public class ServicoToken : Notifiable, IServicoToken
    {
        private string Secret = @"AhsdhajkshdKJA;sldk:Aosjhe\sdddsSDi2wh4518283054d0f98f988t10982c";
        public string GerarToken(int usuarioId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim("UsuarioId", usuarioId.ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string ObterValor(ClaimsPrincipal principal, string name) => principal?.Claims?.SingleOrDefault(p => p.Type == name)?.Value;
        public int ObterValorInt(ClaimsPrincipal principal, string name) => int.Parse(ObterValor(principal, name));
        public string ObterSecret() => Secret;
    }
}
