using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Examples.WebApi.Application.Commands.LazyCommands;

namespace Examples.WebApi.Controllers
{
    // https://rehansaeed.com/asp-net-core-lazy-command-pattern/

    [Route("api/v1/[controller]")]
    public class RocketController : Controller
    {
        private readonly ILogger<RocketController> _logger;

        private readonly Lazy<IGetRocketCommand> _getRocketCommand;
        private readonly Lazy<ILaunchRocketCommand> _launchRocketCommand;

        public RocketController(
            ILogger<RocketController> logger,
            Lazy<IGetRocketCommand> getRocketCommand,
            Lazy<ILaunchRocketCommand> launchRocketCommand)
        {
            _logger = logger;
            _getRocketCommand = getRocketCommand;
            _launchRocketCommand = launchRocketCommand;
        }

        [HttpGet("{rocketId}")]
        public Task<IActionResult> GetRocket(int rocketId) =>
            _getRocketCommand.Value.ExecuteAsync(rocketId);

        [HttpGet("{rocketId}/launch/{planetId}")]
        public Task<IActionResult> LaunchRocket(int rocketId, int planetId) =>
            _launchRocketCommand.Value.ExecuteAsync(rocketId, planetId);

    }
}