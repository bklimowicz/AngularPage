using System;
using Libraries.AuthService.Data;
using Libraries.AuthService.Dtos;
using Libraries.AuthService.Helpers;
using Libraries.AuthService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libraries.AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthController(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Success");
        }

        [HttpPut]
        public IActionResult Register(RegisterDto dto)
        {
            User user = new()
            {
                Email = dto.Email,
                Name = dto.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            User createdUser;

            try
            {
                createdUser = _userRepository.Create(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("Success", createdUser);
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            User user = _userRepository.GetByEmail(dto.Email);

            if (user is null)
            {
                return BadRequest(new
                {
                    message = "User not found"
                });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new
                {
                    message = "Invalid credentials"
                });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt);

            return Ok(new
            {
                message = "Success"
            });
        }
    }
}

