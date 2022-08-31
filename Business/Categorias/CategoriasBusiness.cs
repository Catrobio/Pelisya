using Business.DTOs;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Business.CategoriasBusiness
{
    public interface ICategoriasBusiness
    {
        Task<List<CategoriasDTO>> GetCategorias();
    }

    public class CategoriasBusiness : ICategoriasBusiness
    {
        private pelisyaContext _context;
        private IMapper _mapper;
        public CategoriasBusiness()
        {
            //Instanciamos el context en el constructor
            _context = new pelisyaContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Categoriasusuarios, CategoriasDTO>()               
                .ReverseMap();                
            });
            _mapper = config.CreateMapper();
        }

        public async Task<List<CategoriasDTO>> GetCategorias()
        {
            var result = new List<CategoriasDTO>();

            var categorias = await _context.Categoriasusuarios
                .ToListAsync();

            result = _mapper.Map<List<CategoriasDTO>>(categorias);

            return result;
        }

    }
}
