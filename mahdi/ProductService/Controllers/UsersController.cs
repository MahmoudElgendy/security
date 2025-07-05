using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using productservice.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace productservice.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsersController(JwtOptions jwtOptions) : ControllerBase
    {
        [HttpPost]
        [Route("auth")]
        public ActionResult<string> AuthenticateUser(AuthenticationRequest request)
        {
            if (request.UserName != "admin" || request.Password != "password")
            {
                return BadRequest("Invalid UserName or Password");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
                    SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, request.UserName),
                    new Claim(ClaimTypes.Email, "m@gamil.com"),
                     new Claim("Department", "IT"), // better to replace magic string Department with enum,
                     new Claim(ClaimTypes.Role, "amin") // better to replace magic string Role with enum
                }),


            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = tokenHandler.WriteToken(securityToken);

            return Ok(accessToken);
        }


    }
}
