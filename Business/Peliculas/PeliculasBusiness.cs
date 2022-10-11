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
        Task<PeliculasDTO> UpdatePeliculas(PeliculasDTO peliculaDTO);
        Task<PeliculasDTO> InsertPeliculas(PeliculasDTO peliculaDTO);
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
                .ForMember(
                        dto => dto.Categoria,
                        enty => enty.MapFrom(p => p.IdCategoriaPeliculasNavigation.Descripcion)
                    )
                .ReverseMap();               
            });
            _mapper = config.CreateMapper();
        }

        public async Task<List<PeliculasDTO>> GetPeliculas()
        {
            var result = new List<PeliculasDTO>();

            try
            {
                var peliculas = await _context.Peliculas
                    .Include(p => p.IdCategoriaPeliculasNavigation)
                    .ToListAsync();

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

        public async Task<PeliculasDTO> UpdatePeliculas(PeliculasDTO peliculaDTO)
        {
            var result = new PeliculasDTO();

            try
            {
                /*var pelicula = _mapper.Map<Peliculas>(peliculaDTO);
                _context.Update(pelicula);*/
                var pelicula = await _context.Peliculas
                    .Where(p => p.IdPelicula == peliculaDTO.IdPelicula)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                if(pelicula != null)
                {
                    //pelicula = _mapper.Map<Peliculas>(peliculaDTO); si queremos actualizar todo
                    pelicula.Portada = peliculaDTO.Portada;
                    _context.Update(pelicula);
                    _context.SaveChanges();

                    result = _mapper.Map<PeliculasDTO>(pelicula);
                }
                return result;
            }
            catch (EntityException ee)
            {

                result.ErrorCode = -200;
                result.Message = $"Error interno: {ee.Message}";
                return result;
            }
            catch (Exception e)
            {                
                result.ErrorCode = -100;
                result.Message = $"Error interno {e.Message}";                                
                return result;
            }           
        }

        public async Task<PeliculasDTO> InsertPeliculas(PeliculasDTO peliculaDTO)
        {
            var result = new PeliculasDTO();

            try
            {              
                var pelicula = await _context.Peliculas
                    .Where(p => p.IdImdb == peliculaDTO.IdImdb)                    
                    .FirstOrDefaultAsync();

                if (pelicula == null)
                {
                    var peliculaGuardar = _mapper.Map<Peliculas>(peliculaDTO);

                    // var peliculaGuardada = await _context.AddAsync(peliculaGuardar); Si queremos guardar en una variable la pelicula guardada
                    //
                    //peliculaGuardar.IdCategoriaPeliculasNavigation = null;

                    await _context.AddAsync(peliculaGuardar);

                    await _context.SaveChangesAsync();

                    result = peliculaDTO;

                    //result = _mapper.Map<PeliculasDTO>(peliculaGuardada.Entity); si queremos devolver el id recien guardado
                }
                return result;
            }
            catch (EntityException ee)
            {

                result.ErrorCode = -200;
                result.Message = $"Error interno: {ee.Message}";
                return result;
            }
            catch (Exception e)
            {
                result.ErrorCode = -100;
                result.Message = $"Error interno {e.Message}";
                return result;
            }
        }

    }
}
