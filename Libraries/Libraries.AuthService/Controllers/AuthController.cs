using System;
using Libraries.AuthService.Data;
using Libraries.AuthService.Dtos;
using Libraries.AuthService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Success");
        }

        [HttpPost]
        public IActionResult Register(RegisterDto dto)
        {
            User user = new()
            {
                Email = dto.Email,
                Name = dto.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };            

            return Created("Success", _userRepository.Create(user));
        }
    }
}

