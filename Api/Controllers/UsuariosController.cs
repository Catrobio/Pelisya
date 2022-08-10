using Microsoft.AspNetCore.Mvc;
using Business.Usuarios;
using Business.DTOs;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private UsuariosBusiness usuariosBusiness;
        public UsuariosController()
        {
            usuariosBusiness = new UsuariosBusiness();
        }

        [HttpGet("Lista")]
        public List<UsuariosDTO> ListaUsuarios()
        {
           return usuariosBusiness.GetUsuarios();
        }
    }
}
