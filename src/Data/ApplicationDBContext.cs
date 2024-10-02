using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1.src.Model;
using Microsoft.EntityFrameworkCore;

namespace Catedra1.src.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
       public DbSet<User> Users {get; set;} = null!; 
    }
}