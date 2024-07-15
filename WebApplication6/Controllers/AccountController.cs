using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;
using WebApplication6.Models;
using WebApplication6.Utilities;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var encryptedUserName = Encryptor.Encrypt(loginRequest.UserName);
            var user = _context.Users.SingleOrDefault(u => u.UserName == encryptedUserName);

            if (user == null || !PasswordHasher.VerifyPassword(loginRequest.Password, user.Password))
            {
                return Unauthorized(new { message = "Username or password is incorrect" });
            }

            // Return user details along with role
            var userType = await _context.UserTypes.FindAsync(user.UserTypeID);
            return Ok(new
            {
                userID = user.UserID,
                role = userType.UserTypeName
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var encryptedUserName = Encryptor.Encrypt(registerRequest.UserName);
            if (_context.Users.Any(u => u.UserName == encryptedUserName))
            {
                return BadRequest(new { message = "User already exists" });
            }

            var user = new User
            {
                UserName = registerRequest.UserName,
                Password = registerRequest.Password, // This will be hashed by the setter
                UserTypeID = registerRequest.UserTypeID // Ensure this is a valid UserTypeID
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserTypeID { get; set; }
    }
}
