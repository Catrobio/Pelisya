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

        [HttpGet("Todas")]
        public async Task<List<CategoriasDTO>> GetCategoria()
        {
            return await _categoriasBusiness.GetCategorias();
        }

    }
}
