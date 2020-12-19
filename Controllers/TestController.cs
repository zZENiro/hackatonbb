using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackatonbb.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Method()
        {
            return new JsonResult(new 
            {
                Hello = "World"
            });
        }
    }
}
