using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1.src.Dtos;
using Catedra1.src.Model;

namespace Catedra1.src.Mappers
{
    public static class UserMapper
    {
        public static User ToUserDto(this UserDto userModel)
        {
            return new User
            {
                rut = userModel.rut,
                Name = userModel.Name,
                Correo = userModel.Correo,
                Genre = userModel.Genre,
                fechaNacimiento = userModel.fechaNacimiento
            };
        }
    }
}