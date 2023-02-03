using DigitalBank.Domain.Contracts.Authentication;
using DigitalBank.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalBank.Infra.Data.Authentication;

public class TokenGenerator : ITokenGenerator
{
    public dynamic Generator(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email)
        };

        var expires = DateTime.Now.AddDays(1);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SenhaDoBanco123@"));
        
        var tokenData = new JwtSecurityToken(
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            expires: expires,
            claims: claims
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

        return new
        {
            acess_token = token,
            expirations = expires
        };
    }
}
