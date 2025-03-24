using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserBlogAPI.DTO;
using UserBlogAPI.Models;

namespace UserBlogAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly UserBlogDbContext _context;
        private readonly IConfiguration _configuration;

        public UserAuthController(UserBlogDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (!Request.Headers.TryGetValue("X-Request-Source", out var requestSource) || string.IsNullOrEmpty(requestSource))
                return BadRequest("Missing or invalid request source.");

            if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
                return BadRequest("Email already exists.");

            User user = new User() { Username = userDto.Username, Email = userDto.Email, Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password), Role = userDto.Role };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (!Request.Headers.TryGetValue("X-Request-Source", out var requestSource) || string.IsNullOrEmpty(requestSource))
                return BadRequest("Missing or invalid request source.");

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, existingUser.Password))
                return Unauthorized("Invalid email or password.");

            var token = GenerateJwtToken(existingUser);
            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet("get-profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            if (userId == null) return Unauthorized();

            var user = await _context.Users.FindAsync(int.Parse(userId));
            if (user == null) return NotFound();

            var userDto = new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };

            return Ok(userDto);
        }
    }
}
