using footballLeagueApi.Models;
using FootballLeagueConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/teams
        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _context.Teams.ToList();
            return Ok(teams);
        }

        [HttpPost]
        public IActionResult CreateTeam([FromBody] TeamCreateDto teamDto)
        {
            if (teamDto == null || string.IsNullOrWhiteSpace(teamDto.Name) || string.IsNullOrWhiteSpace(teamDto.City))
                return BadRequest("Name and City are required.");

            var team = new Team
            {
                Name = teamDto.Name,
                City = teamDto.City
            };

            _context.Teams.Add(team);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTeams), new { id = team.TeamId }, team);
        }


    }
}
