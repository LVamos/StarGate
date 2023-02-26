using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for teams
/// </summary>
public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
	/// <summary>
	/// Finds a team by its code.
	/// </summary>
	/// <param name="code">A code string identifying the team</param>
	/// <returns>DTO object of the wanted team or null</returns>
	public Team? FindByCode(string code) => _dbContext.Teams.FirstOrDefault(t => t.Code == code);

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public TeamRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
