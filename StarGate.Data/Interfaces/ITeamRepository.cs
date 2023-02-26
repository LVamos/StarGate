using StarGate.Data.Models;

namespace StarGate.Data.Interfaces;

/// <summary>
/// An interface for a repository of teams
/// </summary>
public interface ITeamRepository : IBaseRepository<Team>
{
	/// <summary>
	/// Finds a team by its code.
	/// </summary>
	/// <param name="code">A code string identifying the team</param>
	/// <returns>DTO object of the wanted team or null</returns>
	Team? FindByCode(string code);
}
