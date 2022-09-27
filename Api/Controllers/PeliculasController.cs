using Microsoft.AspNetCore.Mvc;
using Business.PeliculasBusiness;
using Business.DTOs;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : Controller
    {
        private IPeliculasBusiness _peliculasBusiness;
        public PeliculasController(IPeliculasBusiness peliculasBusiness)
        {
            _peliculasBusiness = peliculasBusiness;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetPeliculas()
        {            
            var  result = await _peliculasBusiness.GetPeliculas();
            if(result != null)
            {
                if(result[0].ErrorCode != null)
                {
                    return StatusCode(500, result);
                }
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
