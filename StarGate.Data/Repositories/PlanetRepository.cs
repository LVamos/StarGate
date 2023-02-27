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
	/// Finds a planet by its code.
	/// </summary>
	/// <param name="code">A code string identifying the planet</param>
	/// <returns>DTO object of the wanted planet or null</returns>
	public Planet? FindByCode(string code) => _dbContext.Planets.FirstOrDefault(p => p.Code == code);

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

	public override Planet Update(Planet entity)
	{
		Planet? entry = FindById(entity.Id);

		if (entity.TeamId == 0)
			entry.Team = null;

		entry.AddressId = entity.AddressId;
		entry.TeamId = entity.TeamId;
		entry.Code = entity.Code;
		entry.Name = entity.Name;
		entry.Safety = entity.Safety;
		entry.Explored = entity.Explored;
		_dbContext.SaveChanges();
		return entry;
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public PlanetRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
