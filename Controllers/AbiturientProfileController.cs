using hackatonbb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackatonbb.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AbiturientProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbiturientProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        
    }
}
