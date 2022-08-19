using AutoMapper;
using Business.DTOs;
using EntityLib;

namespace Business.Mappers
{
    public class UsuariosMapper : Profile
    {
        public UsuariosMapper()
        {
            CreateMap<Usuarios, UsuariosDTO>()
                .ReverseMap();
        }
    }
}
