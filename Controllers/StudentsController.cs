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
            var student = await _context.Students.Where(s => s.VkId == vkId).SingleOrDefaultAsync();

            return new JsonResult(new { CreditCard = student.CreditCardProfile });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddAchievement([FromQuery] string eventName, string place, string role, string level, string vkId) =>
            await Task.Factory.StartNew(() =>
            {
                Achievement achievement = null;

                var student = _context.Students.Where(s => s.VkId == vkId).SingleOrDefault();

                var eventLevel = _context.EventLevels.Where(el => el.Name == level).SingleOrDefault();

                var eventRole = _context.EventRoles.Where(er => er.Name == role).SingleOrDefault();
                if (eventRole is null || eventRole.Name != "Участник")
                {
                    achievement = new Achievement()
                    {
                        EventRole = eventRole,
                        EventLevel = eventLevel,
                        EventName = eventName
                    };

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
            });


    }
}
