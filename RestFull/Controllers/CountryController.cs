using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace RestFull.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Messahe"); 
        }


    }
}
