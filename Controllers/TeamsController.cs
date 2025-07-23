using footballLeagueApi.Models;
using FootballLeagueConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        // GET: api/teams/{id}
        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            var team = _context.Teams.Find(id);

            if (team == null)
                return NotFound();

            return Ok(team);
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
        // PUT: api/teams/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, [FromBody] Team updatedTeam)
        {
            if (id != updatedTeam.TeamId)
                return BadRequest("Team ID mismatch.");

            var existingTeam = _context.Teams.Find(id);
            if (existingTeam == null)
                return NotFound();

            existingTeam.Name = updatedTeam.Name;
            existingTeam.City = updatedTeam.City;

            _context.SaveChanges();

            return NoContent(); // 204 Success with no content
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var team = _context.Teams
                .Include(t => t.Players)
                .Include(t => t.MatchHomeTeams)
                .Include(t => t.MatchAwayTeams)
                .FirstOrDefault(t => t.TeamId == id);

            if (team == null)
                return NotFound();

            // Remove related players and matches (if you want to fully delete them)
            _context.Players.RemoveRange(team.Players);
            _context.Matches.RemoveRange(team.MatchHomeTeams);
            _context.Matches.RemoveRange(team.MatchAwayTeams);

            _context.Teams.Remove(team);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
