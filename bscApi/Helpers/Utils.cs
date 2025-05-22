using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using bscApi.Models;

namespace bscApi.Helpers
{
    public class Utils
    {
        private readonly IConfiguration _configuration;
        public Utils(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public string encryptSHA256(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("La contraseña no puede estar vacía");

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public string generateJwtToken(Persona person)
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, person.IdPersona.ToString()),
                 new Claim(ClaimTypes.Email, person.Correo!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //create token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
