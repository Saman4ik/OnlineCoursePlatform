using Microsoft.IdentityModel.Tokens;
using OnlineCoursePlatform.Modellar;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineCoursePlatform.Services;

public class JwtSettings
{
    public string Secret { get; set; }
}
