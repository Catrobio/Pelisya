using Microsoft.AspNetCore.Mvc;
using Business.UserAccountBusiness;
using Business.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : Controller
    {
        private IUserAccountBusiness _userAccoutBusiness;
        IConfiguration _configuration;
        public UserAccountController(IUserAccountBusiness userAccoutBusiness, IConfiguration configuration)
        {
            _userAccoutBusiness = userAccoutBusiness;
            _configuration = configuration; 
        }

        [HttpPost("Login")]
        public async Task<UserAccountDTO> LoginUser(LoginDTO userLogin)
        {
            var usuario = await _userAccoutBusiness.Authentication(userLogin);
            if(string.IsNullOrEmpty(usuario.Message))
            {
                /*Aca retornamos el token */
                usuario.Token = GenToken(usuario);
                usuario.Validate = DateTime.UtcNow.AddMinutes(30);
                usuario.Created = DateTime.UtcNow;
            }
            return usuario;
        }

        [HttpPost("Create")]
        public async Task<UserAccountDTO> CreateUser(UserAccountDTO usuario)
        {
            return await _userAccoutBusiness.CreateUsuarios(usuario);
        }

        [HttpPut("Update")]
        public UserAccountDTO UpdateUser(UserAccountDTO usuario)
        {
            return  _userAccoutBusiness.UpdateUsuario(usuario);
        }

        [HttpDelete("Delete")]
        public async Task<bool> DeleteUser(int idUsuario)
        {
            return await _userAccoutBusiness.DeleteUsuario(idUsuario);
        }

        [HttpPost("hash")]
        public bool LoginUser()
        {
            return _userAccoutBusiness.HashPassword();
        }

        private string GenToken(UserAccountDTO usuario)
        {
            var key = _configuration["Authentication:SecretKey"];
            var keyBytes = Encoding.ASCII.GetBytes(key);          

            var tokenDescriptor = new SecurityTokenDescriptor
            {                
                Subject = new ClaimsIdentity(
                     new[]
                     {
                        new Claim(
                            ClaimTypes.NameIdentifier,
                            usuario.UserName
                    ),
                        new Claim(
                            ClaimTypes.Role,
                            usuario.IdCategoria.ToString()
                    )
                     }
               ),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(keyBytes), 
                    SecurityAlgorithms.HmacSha256Signature
                )

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string tokencreado = tokenHandler.WriteToken(tokenConfig);

            return tokencreado;
        }


    }
}
