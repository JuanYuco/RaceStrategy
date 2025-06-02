using Microsoft.AspNetCore.Mvc;
using RaceStrategy.Application.Interfaces;
using RaceStrategy.Domain.Ports;

namespace RaceStrategy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StrategyController : Controller
    {
        private readonly IStrategyService _strategyService;
        public StrategyController(IStrategyService strategyService)
        {
            this._strategyService = strategyService;
        }

        [HttpGet("optimal")]
        public async Task<IActionResult> GetOptimalCollection([FromQuery] int maxLaps, [FromQuery] string createdBy, [FromQuery] int driverId)
        {
            var strategyResult = await _strategyService.GetOptimalCollection(new Application.DTOs.Strategy.OptimalStrategyRequestDTO
            {
                CreatedBy = createdBy,
                DriverId = driverId,
                MaxLaps = maxLaps
            });

            if (!strategyResult.Successful)
            {
                return StatusCode(strategyResult.HttpCode, strategyResult.UserMessage);
            }

            return Ok(strategyResult.EntityCollection);
        }
    }
}
