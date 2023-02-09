using DigitalBank.Domain.Contracts.Authentication;
using DigitalBank.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalBank.Infra.Data.Authentication;

public class TokenGenerator : ITokenGenerator
{
    public TokenData Generator(User user)
    {
        var permissions = string.Join(",", user.userPermissions.Select(x => x.Permission.PermissionName));
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("permissions", permissions)
        };

        var expires = DateTime.Now.AddDays(1);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SenhaDoBanco123@"));
        
        var tokenData = new JwtSecurityToken(
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            expires: expires,
            claims: claims
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

        return new TokenData {token = token};
    }
}
