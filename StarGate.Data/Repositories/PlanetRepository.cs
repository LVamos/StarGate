using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for planets
/// </summary>
public class PlanetRepository : BaseRepository<Planet>, IPlanetRepository
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public PlanetRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
