using hackatonbb.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hackatonbb.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class StudentAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] string login, string password)
        {
            var student = await _context.Students.Where(s => s.Login == login).SingleOrDefaultAsync();
            if (student is null)
                return new NotFoundResult();

            if (student.Password != password)
                return new BadRequestResult();

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, login),
                new Claim(ClaimTypes.Role, "User")
            };

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            return (IActionResult)AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, JwtBearerDefaults.AuthenticationScheme));
        }
    }
}
