using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1.src.Model;

namespace Catedra1.src.Data
{
    public class Seeder
    {
        public static async Task Seed(ApplicationDBContext context)
        {
            if(context.Users.Any())
            {
                return;
            }

            var user = new List<User>
            {
                new User
                {
                    rut = "21434135-2",
                    Name = "Cristhian Montoya",
                    Correo = "cochayuyo@gmail.com",
                    Genre = "masculino",
                    fechaNacimiento = new DateOnly(2003, 11, 06)
                },
                new User
                {
                    rut = "7424077-1",
                    Name = "Luis Gahona",
                    Correo = "luisgahona@gmail.com",
                    Genre = "masculino",
                    fechaNacimiento = new DateOnly(1920, 7, 2)
                },
                new User
                {
                    rut = "15012447-6",
                    Name = "Carolina Gahona",
                    Correo = "carolagahona@gmail.com",
                    Genre = "femenino",
                    fechaNacimiento = new DateOnly(1986, 3, 16)
                },
                new User
                {
                    rut = "24567983-k",
                    Name = "Cristobal Montoya",
                    Correo = "totobal@gmail.com",
                    Genre = "masculino",
                    fechaNacimiento = new DateOnly(2007, 7, 24)
                },
                new User
                {
                    rut = "16532345-6",
                    Name = "Abelardo Peña",
                    Correo = "abelardo@gmail.com",
                    Genre = "masculino",
                    fechaNacimiento = new DateOnly(1980, 10, 25)
                },
                new User
                {
                    rut = "8976543-2",
                    Name = "Mireya Araya",
                    Correo = "mireya@gmail.com",
                    Genre = "femenino",
                    fechaNacimiento = new DateOnly(1950, 9, 27)
                },
                new User
                {
                    rut = "19865321-k",
                    Name = "Maria Araya",
                    Correo = "Maria@gmail.com",
                    Genre = "femenino",
                    fechaNacimiento = new DateOnly(1980, 1, 14)
                },
                new User
                {
                    rut = "13678543-1",
                    Name = "Isaias Cabrera",
                    Correo = "cabrera@gmail.com",
                    Genre = "otro",
                    fechaNacimiento = new DateOnly(2000, 7, 30)
                },
                new User
                {
                    rut = "17698123-5",
                    Name = "Cristian de Buyne",
                    Correo = "krostfire@gmail.com",
                    Genre = "otro",
                    fechaNacimiento = new DateOnly(2000, 7, 13)
                },
                new User
                {
                    rut = "17656434-9",
                    Name = "Lionel Messi",
                    Correo = "goat@gmail.com",
                    Genre = "masculino",
                    fechaNacimiento = new DateOnly(1980, 3, 30)
                },
                new User
                {
                    rut = "14465786-k",
                    Name = "Cristiano Ronaldo",
                    Correo = "mrChampions@gmail.com",
                    Genre = "prefiero no decirlo",
                    fechaNacimiento = new DateOnly(1985, 7, 21)
                }
            };

            await context.Users.AddRangeAsync(user);
            await context.SaveChangesAsync();

        }
    }
}