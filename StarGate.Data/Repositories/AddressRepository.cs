using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for addresses
/// </summary>
public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public AddressRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
