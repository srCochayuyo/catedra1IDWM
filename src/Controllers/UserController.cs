using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1.src.Interface;
using Microsoft.AspNetCore.Mvc;
using Catedra1.src.Dtos;
using Catedra1.src.Mappers;

namespace Catedra1.src.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


    [HttpGet("")]
    public async Task<IActionResult> GetAllUsers([FromQuery] string sort = null, [FromQuery] string gender = null)
    {
    // Validaciones de los parámetros de entrada
        if (sort != null && sort.ToLower() != "asc" && sort.ToLower() != "desc")
        {
            return BadRequest("El valor de 'sort' debe ser 'asc' o 'desc'.");
        }

        if  (gender != null && 
            gender.ToLower() != "masculino" && 
            gender.ToLower() != "femenino" && 
            gender.ToLower() != "otro" && 
            gender.ToLower() != "prefiero no decirlo")
        {
            return BadRequest("El valor de 'gender' no es válido.");
        }

    
        var users = await _userRepository.Get(sort, gender);

        return Ok(users);
    }

        //Post
        [HttpPost("")]
        public async Task<IActionResult> CreateProduct( UserDto userDto)
        {

            bool exist = await _userRepository.ExistByCode(userDto.rut);

            if(exist)
            {
                return StatusCode(409, "El rut ya existe");
;
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            } else if(userDto.fechaNacimiento > DateTime.Now)
            {
                return BadRequest("La fecha de nacimiento debe ser anterior a la fecha actual.");
            }

            var userModel = userDto.ToUserDto();
            await _userRepository.Post(userModel);
            return StatusCode(201, "Usuario creado exitosamente");

        }

        
        //Put
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UserDto userDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userModel = await _userRepository.Put(id, userDto);
            if (userModel == null)
            {
                return NotFound();
            }
            return Ok(userModel);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userRepository.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return NoContent();
        }

  
        
    }
}