using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1.src.Data;
using Catedra1.src.Dtos;
using Catedra1.src.Interface;
using Catedra1.src.Model;
using Microsoft.EntityFrameworkCore;

namespace Catedra1.src.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext contex)
        {
            _context = contex;
        }

        public async Task<User?> Delete(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userModel == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<IEnumerable<User>> GetByGenre(string genre)
        {
            return await _context.Users.Where(p => p.Genre == genre).ToListAsync();
        }

        public async Task<User> Post(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Put(int id, UserDto userDto)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userModel == null)
            {
                throw new Exception("User not found");
            }
            userModel.rut = userDto.rut;
            userModel.Name = userDto.Name;
            userModel.Correo = userDto.Correo;
            userModel.Genre = userDto.Genre;
            userModel.fechaNacimiento = userDto.fechaNacimiento;


            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<bool> ExistByCode(string rut)
        {
            return await _context.Users.AnyAsync(p => p.rut == rut);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}