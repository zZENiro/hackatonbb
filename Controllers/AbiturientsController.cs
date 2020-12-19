using hackatonbb.Data;
using hackatonbb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackatonbb.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AbiturientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbiturientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetBankValues([FromQuery] string vkId)
        {
            var abiturient = await _context.Abiturients.Where(a => a.VkId == vkId).SingleOrDefaultAsync();

            if (abiturient is null) return BadRequest(new { Message = "Такого абитуриента нет." });

            return new JsonResult(new { Message = "Данные ВТБ-профиля", VTBProfile = abiturient.CreditCardProfile });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromQuery] string login, string password)
        {
            var abiturient = await _context.Abiturients.Where(a => a.Login == login).SingleOrDefaultAsync();

            if (abiturient is null) return BadRequest(new { Message = "Такого абитуриента нет." });

            var passwordHasher = new PasswordHasher<Abiturient>();
            if (passwordHasher.VerifyHashedPassword(abiturient, abiturient.PasswordHash, password) != PasswordVerificationResult.Success)
                return BadRequest(new { Message = "Не правильный пароль." });

            return new JsonResult(new { Message = "Вы зашли.", Abiturient = abiturient });
        }

    }
}
