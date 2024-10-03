using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1.src.Data;
using Catedra1.src.Dtos;
using Catedra1.src.Model;
using SQLitePCL;

namespace Catedra1.src.Interface
{
    public interface IUserRepository 
    {
        //Post
        Task<User> Post(User user);

        //Put
        Task<User?> Put(int id, UserDto userDto);

        Task<IEnumerable<User>> GetByGenre(string genre);

        Task<User?> Delete(int id);

        Task<bool> ExistByCode(string rut);

        Task<User?> GetById(int id);

    }
}