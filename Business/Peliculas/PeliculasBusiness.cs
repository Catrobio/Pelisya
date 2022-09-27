using AutoMapper;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using Business.DTOs;
using System.Data.Entity.Core;

namespace Business.PeliculasBusiness
{
    public interface IPeliculasBusiness
    {
        Task<List<PeliculasDTO>> GetPeliculas();
    }
    public class PeliculasBusiness : IPeliculasBusiness
    {
        private pelisyaContext _context;
        private IMapper _mapper;
        public PeliculasBusiness()
        {
            //Instanciamos el context en el constructor
            _context = new pelisyaContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Peliculas, PeliculasDTO>()              
                .ReverseMap();               
            });
            _mapper = config.CreateMapper();
        }

        public async Task<List<PeliculasDTO>> GetPeliculas()
        {
            var result = new List<PeliculasDTO>();

            try
            {
                var peliculas = await _context.Peliculas.ToListAsync();

                result = _mapper.Map<List<PeliculasDTO>>(peliculas);
            }
            catch(EntityException ee) 
            {
                var peliculasDTO = new PeliculasDTO
                {
                    ErrorCode = -200,
                    Message = $"Error interno: {ee.Message}"
                };
                result.Add(peliculasDTO);
                return result;
            }
            catch (Exception e)
            {
                var peliculasDTO = new PeliculasDTO
                {
                    ErrorCode = -100,
                    Message = $"Error interno {e.Message}"
                };
                result.Add(peliculasDTO);
                return result;
            }

            return result;
        }

    }
}
