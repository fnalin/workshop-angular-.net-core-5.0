
using Microsoft.AspNetCore.Mvc;

namespace FN.WorkShopNetCoreAngular.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HealthCheckController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()=> Ok();
    }
}