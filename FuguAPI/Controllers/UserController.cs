using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FuguAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly string connection = "Data Source=67.192.16.33;Initial Catalog=Fugu_Dev;User Id = GracieUniversityv3_dev_v02; Password=wyhwrsK^FN5^_LU_; Persist Security Info=True; Connect Timeout = 300; MultipleActiveResultSets=true";

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var learning = new DataStore(connection);

            var result = learning.GetUserById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);     
        }
    }
  }



