using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlateformController : ControllerBase
    {
        public PlateformController()
        {

        }

        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("--> Inbound POST  # command Service");
            return Ok("InBound Test from the Plateform Controller");
        }
    }
}