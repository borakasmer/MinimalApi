using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    WebApplicationBuilder _builder;
    public TokenService(WebApplicationBuilder builder)
    {
        _builder = builder;
    }
    public string GetToken(DbUser user)
    {
        var claims = new[]
      {
      new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
      new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
      new Claim(JwtRegisteredClaimNames.Email, user.Email)
    };

        var token = new JwtSecurityToken
        (
          issuer: _builder.Configuration["Issuer"],
          audience: _builder.Configuration["Audience"],
          claims: claims,
          expires: DateTime.UtcNow.AddDays(60),
          notBefore: DateTime.UtcNow,
          signingCredentials: new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_builder.Configuration["SigningKey"])),
            SecurityAlgorithms.HmacSha256)
        );


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

