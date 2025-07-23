using Microsoft.AspNetCore.Mvc;
using FootballLeagueConsoleApp.Models;

namespace FootballLeagueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly FootballLeagueContext _context;

        public TeamsController(FootballLeagueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _context.Teams.ToList();
            return Ok(teams);
        }
    }
}
