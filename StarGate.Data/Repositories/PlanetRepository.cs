using Microsoft.EntityFrameworkCore;

using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for planets
/// </summary>
public class PlanetRepository : BaseRepository<Planet>, IPlanetRepository
{
	/// <summary>
	/// Deletes a planet.
	/// </summary>
	/// <param name="code">A short string identifying the planet</param>
	/// <returns>True if the planet was deleted</returns>
	public bool Delete(string code)
	{
		//TEntity? entity = _dbSet.FirstOrDefault(e => e.Code == code);
		Planet? planet = _dbContext.Planets.FirstOrDefault(p => p.Code == code);

		if (planet is null)
			return false;

		try
		{
			_dbSet.Remove(planet);
			_dbContext.SaveChanges();
		}
		catch
		{
			_dbContext.Entry(planet).State = EntityState.Unchanged;
			throw;
		}

		return true;
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public PlanetRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
