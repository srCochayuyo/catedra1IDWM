using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra1.src.Model
{
    public class User
    {
        public int Id { get; set; }

        public string rut {get; set;} = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        [RegularExpression(@"masculino|femenino|otro|prefiero no decirlo")]
        public string Genre { get; set; } = string.Empty;

        public DateTime fechaNacimiento {get; set;}
    }
}