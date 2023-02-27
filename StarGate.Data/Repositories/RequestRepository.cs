using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for requests
/// </summary>
public class RequestRepository : BaseRepository<Request>, IRequestRepository
{
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
