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
	/// <param name="code">A short string identifying the team</param>
	/// <param name="name">Name of the team</param>
	/// <param name="members">Number of members belonging to the team</param>
	/// <returns>IActionResult</returns>
	[HttpPut("teams")]
	public IActionResult EditTeam(string code, string name, int members = 1)
	{
		TeamDto team = new TeamDto
		{
			Code = code,
			Name = name,
			Members = members
		};

		TeamDto? updatedTeam = _teamManager.UpdateTeam(code, team);

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

		return CreatedAtAction(nameof(GetTeam), new { Code = newTeam.Code }, newTeam);
	}

	/// <summary>
	///  Deletes a team.
	/// </summary>
	/// <param name="code">A short string identifying the team</param>
	/// <returns>IActionResult</returns>
	[HttpDelete("teams")]
	public IActionResult DeleteTeam(string code)
	{
		if (!_teamManager.DeleteTeam(code))
			return NotFound();

		return Ok();
	}

	/// <summary>
	///  Gets a team.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>IActionResult</returns>
	[HttpGet("teams/{code}")]
	public IActionResult GetTeam(string code)
	{
		TeamDto? team = _teamManager.GetTeamByCode(code);

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