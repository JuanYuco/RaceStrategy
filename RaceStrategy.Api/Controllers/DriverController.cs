using Microsoft.AspNetCore.Mvc;
using RaceStrategy.Application.Interfaces;

namespace RaceStrategy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            this._driverService = driverService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var driverResult = await _driverService.GetAll(new Application.DTOs.Driver.DriverRequestDTO());
            if (!driverResult.Successful)
            {
                return StatusCode(driverResult.HttpCode, driverResult.UserMessage);
            }

            return Ok(driverResult.EntityCollection);
        }
    }
}
