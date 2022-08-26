using Business.DTOs;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.IO;
using System.Text;
using System;
using System.Security.Cryptography;

namespace Business.UserAccountBusiness
{
    public interface IUserAccountBusiness
    {
        Task<UserAccountDTO> Authentication(UserAccountDTO userAccount);
        Task<UserAccountDTO> CreateUsuarios(UserAccountDTO usuario);
        UserAccountDTO UpdateUsuario(UserAccountDTO user);
        bool HashPassword();
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

            if (string.IsNullOrEmpty(userAccount.UserName) || string.IsNullOrEmpty(userAccount.Password))
            {
                result.Error = "Usuario y contraseña no puede ser vacio";
            }
            else
            {
                var usuario = await _context.Usuarios
                    .Where(u =>
                        u.Email == userAccount.UserName
                        ).FirstOrDefaultAsync();


                if (usuario == null)
                {
                    result.Error = "Usuario no existe";
                }
                else
                {
                    

                    if (VerifyHash(userAccount.Password, usuario.Password))
                    {
                        result = _mapper.Map<UserAccountDTO>(usuario);

                        result.Password = "";

                        result.Token = usuario.Email + "." + usuario.Nombre;
                        result.Created = DateTime.Now;
                        result.Validate = DateTime.Now.AddMinutes(5);
                    }
                    else
                    {
                        result.Error = "Usuario o contraseña incorrecta";
                    }
                }
            }
            return result;
        }

        public async Task<UserAccountDTO> CreateUsuarios(UserAccountDTO usuario)
        {
            var result = new UserAccountDTO();

            //consulta del user name / email
            var verificarUsaurio = await _context.Usuarios
                .Where(u => u.Email == usuario.UserName)
                .FirstOrDefaultAsync();
            //si exite el email en la base de datos
            if(verificarUsaurio != null)
            {
                result.ErrorCode = -100;
                result.Message = "Usuario Existente";
                result.Status = false;
                return result;
            }
            //Mapear usuarios entity desde user account dto
            var usuarioMap = _mapper.Map<Usuarios>(usuario);
            //Hashear contraseña
            usuarioMap.Password = Hash(usuarioMap.Password);
            //Le damos la fecha del servidor a la fecha de alta del usuario
            usuarioMap.FechaAlta = DateTime.Now;
            //Guardamos y guardamos en una variable
            var usuarioGardado = await _context.AddAsync(usuarioMap);
            await _context.SaveChangesAsync();

            result = _mapper.Map<UserAccountDTO>(usuarioGardado.Entity);

            //Devolvemos la contraseña en null
            result.Password = null;

            return result;
        }

        public UserAccountDTO UpdateUsuario(UserAccountDTO user)
        {
            var result = new UserAccountDTO();
            //consulta de el user id 
            var verificarUsaurio =  _context.Usuarios
                .Where(u=>u.IdUsuario == user.IdUsuario)
                .FirstOrDefault();
            //si exite el email en la base de datos
            if (verificarUsaurio == null)
            {
                result.ErrorCode = -200;
                result.Message = "Usuario no Existe";
                result.Status = false;
                return result;
            }
            //verifico si el password es null 
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = Hash(user.Password);
            }
            //Mapeamos la clase
            verificarUsaurio = _mapper.Map<Usuarios>(user);
            //Update de usuarios
            var usuarioActualizado = _context.Update(verificarUsaurio);
            _context.SaveChanges();
            //Mapeo para retornar el dto
            result = _mapper.Map<UserAccountDTO>(usuarioActualizado.Entity);
            result.Password = null;

            return result;
        }

        public bool HashPassword()
        {
            var usuarios = _context.Usuarios.ToList();

            foreach (var usuario in usuarios)
            {
                usuario.Password = Hash(usuario.Password);
                _context.Update(usuario);
                _context.SaveChanges();
            }
            
            return true;
        }

        private string Hash(string textPlain)
        {
            byte[] salt;
            byte[] buffer;
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(textPlain, 16, 100))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(32);
            }

            byte[] dst = new byte[87];
            Buffer.BlockCopy(salt, 0, dst, 1, 16);
            Buffer.BlockCopy(buffer, 0, dst, 17, 32);
            return Convert.ToBase64String(dst);
        }

        private bool VerifyHash(string password, string hash)
        {
            byte[] buffer;
            byte[] src = Convert.FromBase64String(hash);
            if (src.Length != 87 || src[0] != 0)
                return false;
            byte[] dst = new byte[16];
            Buffer.BlockCopy(src, 1, dst, 0, 16);
            byte[] buffer2 = new byte[32];
            Buffer.BlockCopy(src, 17, buffer2, 0, 32);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 100))
            {                
                buffer = bytes.GetBytes(32);
            }
            return buffer2.SequenceEqual(buffer);
        }


    }   
}
