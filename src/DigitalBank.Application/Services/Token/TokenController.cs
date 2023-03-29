using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DigitalBank.Application.Services.Token;

public class TokenController
{
    private const string EmailAlias = "email";
    private readonly int _lifetimeInMinutes;
    private readonly string _securityKey;

    public TokenController(int lifetimeInMinutes, string securityKey)
    {
        _lifetimeInMinutes = lifetimeInMinutes;
        _securityKey = securityKey;
    }

    public string GenerateToken(string userEmail)
    {
        var claims = new List<Claim>
        {
            new Claim(EmailAlias, userEmail)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_lifetimeInMinutes),
            SigningCredentials = new SigningCredentials(
                SymetricKey(),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var parametersValidation = new TokenValidationParameters
        {
            RequireExpirationTime = true,
            IssuerSigningKey = SymetricKey(),
            ClockSkew = new TimeSpan(0),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

        var claims = tokenHandler.ValidateToken(token, parametersValidation, out _);
        return claims;
    }

    public string RecoverEmail(string token)
    {
        var claims = ValidateToken(token);

        return claims.FindFirst(EmailAlias).Value;
    }

    private SymmetricSecurityKey SymetricKey()
    {
        var symetricKey = Convert.FromBase64String(_securityKey);
        return new SymmetricSecurityKey(symetricKey);
    }
}
