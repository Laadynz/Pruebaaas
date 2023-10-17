using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pruebaaas.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pruebaaas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public CuentasController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<ActionResult<TokenJwtDto>> CrearUsuario([FromBody] LoginDto model)
        {
            var usuario = new IdentityUser { UserName = model.Email, Email = model.Email };
            var resultado = await userManager.CreateAsync(usuario, model.Password);

            if (resultado.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                return BadRequest(resultado.Errors.First());
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenJwtDto>> Login([FromBody] LoginDto model)
        {
            var resultado = await signInManager.PasswordSignInAsync(model.Email,
                model.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                return BadRequest("Credenciales inválidas");
            }

        }

        private TokenJwtDto BuildToken(LoginDto user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("miValor", "equis")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddHours(2);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return new TokenJwtDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

        }
    }

}
