using StarGate.Business.Models;

namespace StarGate.Business.Interfaces;

/// <summary>
///  A team manager interface.
/// </summary>
public interface ITeamManager
{
	/// <summary>
	///  Adds a team.
	/// </summary>
	/// <param name="teamDto">The team to be added as an DTO object</param>
	/// <returns>Newly added team as an DTO object</returns>
	TeamDto AddTeam(TeamDto teamDto);

	/// <summary>
	/// Deletes a team.
	/// </summary>
	/// <param name="id">Id of the team to be deleted</param>
	/// <returns>True if the specified team was deleted</returns>
	bool DeleteTeam(int id);

	/// <summary>
	/// Deletes a team.
	/// </summary>
	/// <param name="code">A short string identifying the team</param>
	/// <returns>True if the team was deleted</returns>
	bool DeleteTeam(string code);

	/// <summary>
	///  Returns all teams.
	/// </summary>
	/// <returns>A list of teams</returns>
	IList<TeamDto> GetAllTeams();

	/// <summary>
	///  Gets a team.
	/// </summary>
	/// <param name="id">Id of the requested team</param>
	/// <returns>A data transformation object</returns>
	TeamDto? GetTeam(int id);

	/// <summary>
	/// Finds a team by its code.
	/// </summary>
	/// <param name="code">A code string identifying the team</param>
	/// <returns>DTO object of the wanted team or null</returns>
	TeamDto? GetTeamByCode(string code);


	/// <summary>
	/// Updates a team.
	/// </summary>
	/// <param name="id">Id of the team to be updated</param>
	/// <param name="teamDto">DTO object with modified team</param>
	/// <returns>The updated team or null if the specified team wasn't found</returns>
	TeamDto? UpdateTeam(int id, TeamDto teamDto);
}