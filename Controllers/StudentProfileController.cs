using hackatonbb.Data;
using hackatonbb.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hackatonbb.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "jwt")]
    public class StudentProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTop() => await Task.Factory.StartNew(() =>
            new JsonResult(_context.Students.OrderByDescending(s => s.Raiting).Take(100).ToList()));

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetHistory() => await Task.Factory.StartNew(() =>
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = _context.Students.Where(s => s.Login == curUser).SingleOrDefault();

            var history = curStudent.RaitingTimeStamps.ToList();

            return new JsonResult(history);
        });

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCurrentPriveleges() => await Task.Factory.StartNew(() =>
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = _context.Students.Where(s => s.Login == curUser).SingleOrDefault();

            var currentPriveleges = curStudent.Priveleges.Select(p => p.Privelege).ToList();

            return new JsonResult(currentPriveleges);
        });

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPriveleges() => await Task.Factory.StartNew(() =>
        {
            var priveleges = _context.Priveleges.ToList();

            return new JsonResult(priveleges);
        });

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFilteredPriveleges([FromQuery] string filter) => await Task.Factory.StartNew(() =>
        {
            var sphere = _context.Spheres.Where(s => s.Name == filter).SingleOrDefault();

            var filteredPriveleges = _context.Priveleges.Where(p => p.Sphere == sphere).ToList();

            return new JsonResult(filteredPriveleges);
        });

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddPrivelege([FromQuery] string id) => await Task.Factory.StartNew(() =>
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = _context.Students.Where(s => s.Login == curUser).SingleOrDefault();

            var privelege = _context.Priveleges.Where(p => p.Id == int.Parse(id)).SingleOrDefault();

            var new_rel = new Priveleges2Students()
            {
                IsUsed = false,
                Privelege = privelege,
                Student = curStudent,
                ExpireDate = DateTime.Now.AddMonths(3)
            };

            _context.Add<Priveleges2Students>(new_rel);
            _context.SaveChanges();

            return new OkResult();
        });

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> RemovePrivelege([FromQuery] string id) => await Task.Factory.StartNew(() =>
        {
            var curUser = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value;

            var curStudent = _context.Students.Where(s => s.Login == curUser).SingleOrDefault();

            var privelege = _context.Priveleges.Where(p => p.Id == int.Parse(id)).SingleOrDefault();

            var m2m_rel = _context.Priveleges2Students
                                  .Where(rel => rel.Privelege == privelege && rel.Student == curStudent)
                                  .SingleOrDefault();

            _context.Remove(m2m_rel);
            _context.SaveChanges();

            return new OkResult();
        });

        //[HttpGet]
        //[Route("[action]")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Get
    }
}
