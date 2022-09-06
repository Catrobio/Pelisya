using Microsoft.AspNetCore.Mvc;
using Business.UsuariosBusinnes;
using Business.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
   
    public class UsuariosController : Controller
    {
        private IUsuariosBusiness _usuariosBusiness;
        public UsuariosController(IUsuariosBusiness usuariosBusiness)
        {
            _usuariosBusiness = usuariosBusiness;
        }        
        [HttpGet("Lista")]
        public List<UsuariosDTO> ListaUsuarios()
        {
           return _usuariosBusiness.GetUsuarios();
        }

        [HttpGet("{idUsuario}")]
        public UsuariosDTO GetUsuarioById(int idUsuario)
        {
            return _usuariosBusiness.GetUsuarioById(idUsuario);
        }
    }
}
