using hackatonbb.Data;
using hackatonbb.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace hackatonbb.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class StudentProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public class AchievementInput
        {
            public string Name { get; set; }

            public string EventLevel { get; set; }

            public string EventRole { get; set; }

            public string Sphere { get; set; }

            public string Description { get; set; }

            public int? Place { get; set; }
        }

        public class TopFaculty
        {
            public string Name { get; set; }

            public double Score { get; set; }
        }

        public StudentProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCourses()
        {
            var cources = await _context.Courses.ToListAsync();

            return new JsonResult(cources);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetBoughtCourses()
        {
            var studentLogin = HttpContext.User.Claims.Where(prop => prop.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;
            var currStudent = await _context.Students.Include(prop => prop.BoughtCourses).Where(s => s.Login == studentLogin).SingleOrDefaultAsync();

            return new JsonResult(currStudent?.BoughtCourses);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAchieves()
        {
            var studentLogin = HttpContext.User.Claims.Where(prop => prop.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;
            var currStudent = await _context.Students.Include(prop => prop.Achievements).Where(s => s.Login == studentLogin).SingleOrDefaultAsync();

            return new JsonResult(currStudent?.Achievements);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddAchievement([FromBody] AchievementInput achievement)
        {
            Achievement newAchievement;

            var studentLogin = HttpContext.User.Claims.Where(prop => prop.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;
            var currStudent = await _context.Students.Where(s => s.Login == studentLogin).SingleOrDefaultAsync();

            var eventRole = await _context.EventRoles.Where(role => role.Name == achievement.EventRole).SingleOrDefaultAsync();
            var eventLevel = await _context.EventLevels.Where(lvl => lvl.Name == achievement.EventLevel).SingleOrDefaultAsync();

            if (achievement.Place is null)
            {
                newAchievement = new Achievement()
                {
                    EventLevel = eventLevel,
                    EventRole = eventRole,
                    EventDescribtion = achievement.Description,
                    EventName = achievement.Name
                };

                currStudent.Achievements.Add(newAchievement);
                await _context.SaveChangesAsync();
                return new OkResult();
            }

            newAchievement = new Achievement()
            {
                EventLevel = eventLevel,
                EventRole = eventRole,
                EventDescribtion = achievement.Description,
                EventName = achievement.Name,
                ResultPlace = achievement.Place
            };

            currStudent.Achievements.Add(newAchievement);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTopFaculties()
        {
            var facultyScores = new List<TopFaculty>();

            var faculties = _context.Faculties.Include(prop => prop.Specs).ThenInclude(prop => prop.Students);

            foreach (var faculty in faculties)
            {
                double summaryScore = 0.0;
                var studentsCount = 0;

                foreach (var spec in faculty.Specs)
                {
                    summaryScore += spec.Students.Select(s => s.Raiting).Sum();
                    studentsCount += spec.Students.Count;
                }

                facultyScores.Add(new TopFaculty() { Name = "", Score = Math.Ceiling((summaryScore / studentsCount)) });
            }

            return new JsonResult(facultyScores);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTop()
        {
            var top100 = await _context.Students.OrderByDescending(s => s.Raiting).Take(100).ToListAsync();
                        
            return new JsonResult(top100);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetHistory() 
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = await _context.Students.Include(prop => prop.RaitingTimeStamps).Where(s => s.Login == curUser).SingleOrDefaultAsync();

            var history = curStudent.RaitingTimeStamps.ToList();

            return new JsonResult(history);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCurrentPriveleges() 
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = await _context.Students.Include(prop => prop.Priveleges).Where(s => s.Login == curUser).SingleOrDefaultAsync();

            var currentPriveleges = curStudent.Priveleges.Select(p => p.Privelege).ToList();

            return new JsonResult(currentPriveleges);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPriveleges()
        {
            var priveleges = await _context.Priveleges.ToListAsync();

            return new JsonResult(priveleges);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFilteredPriveleges([FromQuery] string filter)
        {
            var sphere = await _context.Spheres.Where(s => s.Name == filter).SingleOrDefaultAsync();

            var filteredPriveleges = _context.Priveleges.Where(p => p.Sphere == sphere).ToList();

            return new JsonResult(filteredPriveleges);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddPrivelege([FromQuery] string id)
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = await _context.Students.Where(s => s.Login == curUser).SingleOrDefaultAsync();

            var privelege = await _context.Priveleges.Where(p => p.Id == int.Parse(id)).SingleOrDefaultAsync();

            var new_rel = new Priveleges2Students()
            {
                IsUsed = false,
                Privelege = privelege,
                Student = curStudent,
                ExpireDate = DateTime.Now.AddMonths(3)
            };

            _context.Add<Priveleges2Students>(new_rel);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> RemovePrivelege([FromQuery] string id)
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = await _context.Students.Where(s => s.Login == curUser).SingleOrDefaultAsync();

            var privelege = await _context.Priveleges.Where(p => p.Id == int.Parse(id)).SingleOrDefaultAsync();

            var m2m_rel = await _context.Priveleges2Students
                                  .Include(prop => prop.Privelege)
                                  .Include(prop => prop.Student)
                                  .Where(rel => rel.Privelege == privelege && rel.Student == curStudent)
                                  .SingleOrDefaultAsync();

            _context.Remove(m2m_rel);
            await _context.SaveChangesAsync();

            return new OkResult();
        }
    }
}
