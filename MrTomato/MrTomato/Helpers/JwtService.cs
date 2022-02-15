using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrTomato.Helpers
{
    public class JwtService
    {
        private string secureKey = "mrtomatosecurekeystring";
        public string GenerateToken (int id)
        {
            var bytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var credentials = new SigningCredentials(bytes, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddMinutes(5));
            var secToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(secToken);
        }
    }
}
