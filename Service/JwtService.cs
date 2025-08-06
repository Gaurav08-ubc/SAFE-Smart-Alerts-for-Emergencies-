using Microsoft.IdentityModel.Tokens;
using SAFE.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService
{
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:SecretKey"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
        }

        public string GenerateToken(string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role) // 👈 Essential for [Authorize(Roles = "...")]
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    
}





    //private readonly IConfiguration _configuration;

    //public JwtService(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    //public string GenerateToken(object identity, string v)
    //{
    //    var claims = new List<Claim>();

    //    if (identity is User user)
    //    {
    //        claims.Add(new Claim(ClaimTypes.Name, user.Name));
    //        //claims.Add(new Claim(ClaimTypes.Role, "User"));
    //        claims.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User"));
    //    }
    //    else if (identity is Admin admin)
    //    {
    //        claims.Add(new Claim(ClaimTypes.Name, admin.Username));
    //        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
    //    }

    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //    var token = new JwtSecurityToken(
    //        issuer: _configuration["Jwt:Issuer"],
    //        audience: _configuration["Jwt:Audience"],
    //        claims: claims,
    //        expires: DateTime.Now.AddHours(1),
    //        signingCredentials: creds);

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}
