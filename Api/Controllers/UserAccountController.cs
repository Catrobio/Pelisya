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
        public async Task<UserAccountDTO> LoginUser(UserAccountDTO userAccount)
        {
            return await _userAccoutBusiness.Authentication(userAccount);
        }
      
    }
}
