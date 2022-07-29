using System;
using Libraries.SqlDBConnector.Data;
using Libraries.AuthService.Dtos;
using Libraries.AuthService.Helpers;
using Libraries.SqlDBConnector.Models;
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
            if (dto.Email is null) return BadRequest("Missing email information");
            if (dto.Name is null) return BadRequest("Missing name information.");

            User user = new()
            {
                Email = dto.Email,
                Name = dto.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            User? createdUser;

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
            if (dto.Email is null) return BadRequest("Missing email information");
            User? user = _userRepository.GetByEmail(dto.Email);

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

        public new IActionResult User()
        {
            var jwt = Request.Cookies["jwt"];

            if (jwt is null) return Unauthorized("Token is missing");

            var token = _jwtService.Verify(jwt);
            int userId = int.Parse(token.Issuer);

            var user = _userRepository.GetById(userId);

            return Ok(user);
        }
    }
}

