using Business.DTOs;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Business.UserAccountBusiness
{
    public interface IUserAccountBusiness
    {
        Task<UserAccountDTO> Authentication(UserAccountDTO userAccount);
    }
    public class UserAccountBusiness : IUserAccountBusiness
    {
        private pelisyaContext _context;
        private IMapper _mapper;   
        public UserAccountBusiness()
        {
            //Instanciamos el context en el constructor
            _context = new pelisyaContext();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuarios, UserAccountDTO>()
                .ForMember(
                        dto => dto.UserName,
                        enty => enty.MapFrom(p => p.Email)
                    )
                .ReverseMap();                
            });
            _mapper = config.CreateMapper();            
        }

        public async Task<UserAccountDTO> Authentication(UserAccountDTO userAccount)
        {
            var result = new UserAccountDTO();

            if(string.IsNullOrEmpty(userAccount.UserName) || string.IsNullOrEmpty(userAccount.Password))
            {
                result.Error = "Usuario y contraseña no puede ser vacio";
            }
            else
            {
                var usuario = await _context.Usuarios
                    .Where(u =>
                        u.Email == userAccount.UserName
                        &&
                        u.Password == userAccount.Password
                        ).FirstOrDefaultAsync();

                if (usuario == null)
                {
                    result.Error = "Usuario o contraseña incorrecta";                   
                }
                else
                {
                    result = _mapper.Map<UserAccountDTO>(usuario);

                    result.Password = "";

                    result.Token = usuario.Email + "." + usuario.Nombre;
                    result.Created = DateTime.Now;
                    result.Validate = DateTime.Now.AddMinutes(5);
                }                
            }                    
            return result;
        }                                         
    }   
}
