using hackatonbb.Data;
using hackatonbb.Models;
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
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetBankValues([FromQuery] string vkId)
        {
            var student = await _context.Students.Include(prop => prop.CreditCardProfile).Where(s => s.VkId == vkId).SingleOrDefaultAsync();

            return new JsonResult(new { CreditCard = student.CreditCardProfile });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddAchievement([FromQuery] string eventName, string place, string role, string level, string vkId)
        {
            Achievement achievement = null;

            var student = await _context.Students.Include(prop => prop.Achievements).Where(s => s.VkId == vkId).SingleOrDefaultAsync();

            var eventLevel = await _context.EventLevels.Where(el => el.Name == level).SingleOrDefaultAsync();

            var eventRole = await _context.EventRoles.Where(er => er.Name == role).SingleOrDefaultAsync();
            if (eventRole is null || eventRole.Name != "Участник")
            {
                achievement = new Achievement()
                {
                    EventRole = eventRole,
                    EventLevel = eventLevel,
                    EventName = eventName
                };

                if (student.Achievements is null)
                {
                    _context.Achievements.Add(achievement);
                    _context.SaveChanges();
                    return new OkResult();
                }

                student.Achievements.Add(achievement);
                _context.SaveChanges();

                return new OkResult();
            }

            achievement = new Achievement()
            {
                ResultPlace = int.Parse(place),
                EventRole = eventRole,
                EventLevel = eventLevel,
                EventName = eventName
            };

            student.Achievements.Add(achievement);
            _context.SaveChanges();

            return new OkResult();
        }


    }
}
