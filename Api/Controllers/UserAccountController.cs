using Microsoft.AspNetCore.Mvc;
using Business.UserAccountBusiness;
using Business.DTOs;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : Controller
    {
        private IUserAccountBusiness _userAccoutBusiness;
        public UserAccountController(IUserAccountBusiness userAccoutBusiness)
        {
            _userAccoutBusiness = userAccoutBusiness;
        }

        [HttpPost("Login")]
        public async Task<UserAccountDTO> LoginUser(LoginDTO userLogin)
        {
            return await _userAccoutBusiness.Authentication(userLogin);
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

    }
}
