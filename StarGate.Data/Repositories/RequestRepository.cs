using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for requests
/// </summary>
public class RequestRepository : BaseRepository<Request>, IRequestRepository
{
	/// <summary>
	/// Updates a record in the repository.
	/// </summary>
	/// <param name="entity">The modified record</param>
	/// <returns>The modified record</returns>
	public override Request? Update(Request entity)
	{
		Request? entry = FindById(entity.Id);

		if (entity.PlanetId == 0)
			entry.Planet = null;

		entry.Type = entity.Type;
		entry.PlanetId = entity.PlanetId;

		_dbContext.SaveChanges();
		return entry;
	}


	/// <summary>
	/// Finds a request by its code.
	/// </summary>
	/// <param name="code">A code string identifying the request</param>
	/// <returns>DTO object of the wanted request or null</returns>
	public Request? FindByCode(string code) => _dbContext.Requests.FirstOrDefault(s => s.Code == code);

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public RequestRepository(StarGateDbContext dbContext) : base(dbContext) { }
}
