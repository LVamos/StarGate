using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for requests
/// </summary>
public class RequestRepository : BaseRepository<Request>, IRequestRepository
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public RequestRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
