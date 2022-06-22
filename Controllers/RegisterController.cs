using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xpense.Data;
using Xpense.DTOs;
using Xpense.Models;

namespace Xpense.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ExpenseContext _context;
        public RegisterController(ExpenseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);

            if (user != null)
            {
                return BadRequest("User already exists.");
            }

            User newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

    }
}