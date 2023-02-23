using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for teams
/// </summary>
public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public TeamRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
