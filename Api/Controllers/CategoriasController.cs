using Microsoft.AspNetCore.Mvc;
using Business.CategoriasBusiness;
using Business.DTOs;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private ICategoriasBusiness _categoriasBusiness;
        public CategoriasController(ICategoriasBusiness categoriasBusiness)
        {
            _categoriasBusiness = categoriasBusiness;
        }

        [HttpGet("Usuarios")]
        public async Task<List<CategoriasDTO>> GetCategoriaUsuarios()
        {
            return await _categoriasBusiness.GetCategorias();
        }

        [HttpGet("Peliculas")]
        public async Task<List<CategoriasDTO>> GetCategoriaPeliculas()
        {
            return await _categoriasBusiness.GetCategoriasPeliculas();
        }

    }
}
