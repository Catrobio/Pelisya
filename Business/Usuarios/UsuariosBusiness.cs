using Business.DTOs;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Business.UsuariosBusinnes
{
    public interface IUsuariosBusiness
    {
        List<UsuariosDTO> GetUsuarios();
        UsuariosDTO GetUsuarioById(int IdUsuario);        
    }
    public class UsuariosBusiness : IUsuariosBusiness
    {
        private pelisyaContext _context;
        private IMapper _mapper;   
        public UsuariosBusiness()
        {
            //Instanciamos el context en el constructor
            _context = new pelisyaContext();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuarios, UsuariosDTO>()
                .ForMember(
                        dto => dto.ListaFacturas,
                        enty => enty.MapFrom(p => p.Facturasporcobrar)
                    )
                .ReverseMap();
                cfg.CreateMap<Facturasporcobrar, FacturasporcobrarDTO>().ReverseMap();
            });
            _mapper = config.CreateMapper();            
        }

        public List<UsuariosDTO> GetUsuarios()
        {
            //Inicializamos una lista vacia DTO para devolver los datos mejor elaborados y no exponer la entidad
            var result = new List<UsuariosDTO>();           
            //Aca amrmamos la consulta al context de la base de datos a la tabla usuarios
            var usuariosYFacturas = _context.Usuarios
                //Con el include hacemos un left join a la tabla facturasporobrar
                .Include(u => u.Facturasporcobrar)
                .ToList();

            result = _mapper.Map<List<UsuariosDTO>>(usuariosYFacturas);

            //Iteramos el resultado para asignar cada valor que devuelve y agregarlo dentro de la lista DTO
            /*foreach (var usuarios in usuariosYFacturas)
            {
                var usuariosDTO = new UsuariosDTO
                {
                    Apellido = usuarios.Apellido,
                    Email = usuarios.Email,
                    FechaAlta = usuarios.FechaAlta,
                    FechaNacimiento = usuarios.FechaNacimiento,
                    IdCategoria = usuarios.IdCategoria,
                    IdUsuario = usuarios.IdUsuario,
                    Nombre = usuarios.Nombre
                };
                //Creamos una variable lista de facturasporcobrarDTO por cada registro iterado
                var listFacturas = new List<FacturasporcobrarDTO>();
                //Iteramos los resultados de usuarios.Facturasporcobrar donde usuarios es el resultado que estamos iterando de la consulta y Facturasporcobrar las facturas asociadas al usuario
                foreach (var facturas in usuarios.Facturasporcobrar)
                {
                    //Asignamos los valores al DTO
                    var facturasDTO = new FacturasporcobrarDTO
                    {
                        Fecha = facturas.Fecha,
                        IdEstado = facturas.IdEstado,
                        IdFactura = facturas.IdFactura,
                        Monto = facturas.Monto,
                        MontoTax = facturas.MontoTax,
                        MontoTotal = facturas.MontoTotal,
                        Periodo = facturas.Periodo

                    };
                    //Agregamos el resultado a la lista 
                    listFacturas.Add(facturasDTO);
                    //El siclo se repetirá por cada factura de cada usuario
                }
                //Asignamosel resultado de la lista que se iteró previamente
                usuariosDTO.Facturasporcobrar = listFacturas;
                //Agregamos UsuariosDTO a la lista resultado
                result.Add(usuariosDTO);
                //Este ciclo se repite por cada usuario
            }*/

            return result;
        }
        public UsuariosDTO GetUsuarioById(int idUsuario)
        {
            var result = new UsuariosDTO();

            var usuario = _context.Usuarios
                .Include(f => f.Facturasporcobrar)
                .Where(u => u.IdUsuario == idUsuario)
                .FirstOrDefault();

            result = _mapper.Map<UsuariosDTO>(usuario);         
            
            return result;
        }
        
    }   
}
