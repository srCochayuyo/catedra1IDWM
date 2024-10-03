using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1.src.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Catedra1.src.Dtos;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
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


        [HttpGet("Genre/{Genre}")]
        public async Task<IActionResult> GetByCategory([FromRoute] string genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetByGenre(genre);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        //Post
        [HttpPost("")]
        public async Task<IActionResult> CreateProduct( UserDto userDto)
        {

            bool exist = await _userRepository.ExistByCode(userDto.rut);

            if(exist)
            {
                return Conflict("El user ya existe");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = userDto.ToUserDto();
            await _userRepository.Post(userModel);
             return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto);

        }
        
    }
}