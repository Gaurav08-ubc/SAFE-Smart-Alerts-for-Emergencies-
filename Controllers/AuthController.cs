using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAFE.DTO;
using SAFE.Models;

namespace SAFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly SafeContext _context;

        public AuthController(SafeContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("user-login")]
        public IActionResult Login(LoginDto login)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Name == login.Name && u.Password == login.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid user credentials" });

            var token = _jwtService.GenerateToken(user.Name, "User"); // Include name and role
            return Ok(new { token });
        }

        [HttpPost("admin-login")]
        [AllowAnonymous]
        public IActionResult AdminLogin(AdminDto Alogin)
        {
            var admin = _context.Admins
                .FirstOrDefault(a => a.Username == Alogin.UserName && a.Password == Alogin.Password);

            if (admin == null)
                return Unauthorized(new { message = "Invalid admin credentials" });

            var token = _jwtService.GenerateToken(admin.Username, "Admin"); // Include username and role
            return Ok(new { token });
        }
    }
}





















//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SAFE.DTO;
//using SAFE.Models;


//namespace SAFE.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly JwtService _jwtService;
//        private readonly SafeContext _context;

//        public AuthController(SafeContext context, JwtService jwtService)
//        {
//            _context = context;
//            _jwtService = jwtService;
//        }

//        [HttpPost("user-login")]
//        public IActionResult Login(LoginDto login)
//        {
//            var user = _context.Users.FirstOrDefault(u => u.Name == login.Name && u.Password == login.Password);
//            if (user == null) return Unauthorized();

//            var token = _jwtService.GenerateToken(user);
//            return Ok(new { token });
//        }

//        [HttpPost("admin-login")]
//        [AllowAnonymous]
//        public IActionResult AdminLogin(AdminDto Alogin)
//        {
//            var admin = _context.Admins
//                .FirstOrDefault(a => a.Username == Alogin.UserName && a.Password == Alogin.Password);

//            if (admin == null)
//                return Unauthorized(new { message = "Invalid admin credentials" });

//            var token = _jwtService.GenerateToken(admin); // Admin type
//            return Ok(new { token });
//        }
//    }
//}
