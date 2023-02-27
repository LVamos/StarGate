using Microsoft.AspNetCore.Mvc;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;

namespace StarGate.Controllers;

/// <summary>
///  A teams controller.
/// </summary>
[Route("api")]
[ApiController]
public class TeamsController : ControllerBase
{
	/// <summary>
	/// Updates a team.
	/// </summary>
	/// <param name="id">Id of the team to be updated</param>
	/// <param name="team">DTO object with modified team</param>
	/// <returns>IActionResult</returns>
	[HttpPut("teams/{id}")]
	public IActionResult EditTeam(int id, [FromBody] TeamDto team)
	{
		TeamDto? updatedTeam = _teamManager.UpdateTeam(id, team);

		if (updatedTeam is null)
			return NotFound();

		return Ok(updatedTeam);
	}

	/// <summary>
	/// Adds a team.
	/// </summary>
	/// <param name="code">A short string identifying the team</param>
	/// <param name="name">Name of the team</param>
	/// <param name="file">Picture of the team</param>
	/// <returns>IActionResult</returns>
	[HttpPost("teams")]
	public IActionResult AddTeam(string code, string name, int members = 1)
	{
		TeamDto team = new TeamDto
		{
			Code = code,
			Name = name,
			Members = members
		};

		TeamDto? newTeam = _teamManager.AddTeam(team);

		if (team is null)
			return Problem(title: "Error", detail: "The team could not be added.", statusCode: 500);

		return CreatedAtAction(nameof(GetTeam), new { Id = newTeam.Id }, newTeam);
	}

	/// <summary>
	///  Deletes a team.
	/// </summary>
	/// <param name="id">Id of the team to be deleted</param>
	/// <returns>IActionResult</returns>
	[HttpDelete("teams/{id}")]
	public IActionResult DeleteTeam(int id) => _teamManager.DeleteTeam(id) ? Ok() : NotFound();

	/// <summary>
	///  Gets a team.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>IActionResult</returns>
	[HttpGet("teams/{id}")]
	public IActionResult GetTeam(int id)
	{
		TeamDto? team = _teamManager.GetTeam(id);

		return team is null ? NotFound() : Ok(team);
	}

	/// <summary>
	///  Gets all teams.
	/// </summary>
	/// <returns>ienumeration of teams</returns>
	[HttpGet("teams")]
	public IEnumerable<TeamDto> GetTeams() => _teamManager.GetAllTeams();

	/// <summary>
	///  A team manager.
	/// </summary>
	private readonly ITeamManager _teamManager;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="teamManager">A team manager</param>
	public TeamsController(ITeamManager teamManager) => _teamManager = teamManager;
}