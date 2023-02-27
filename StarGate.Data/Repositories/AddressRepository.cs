using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for addresses
/// </summary>
public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
	/// <summary>
	/// Finds an address by its symbols.
	/// </summary>
	/// <param name="symbolCode1">Code of the 1st symbol of the address</param>
	/// <param name="symbolCode2">Code of the 2nd symbol of the address</param>
	/// <param name="symbolCode3">Code of the 3rd symbol of the address</param>
	/// <param name="symbolCode4">Code of the 4th symbol of the address</param>
	/// <param name="symbolCode5">Code of the 5th symbol of the address</param>
	/// <param name="symbolCode6">Code of the 6th symbol fo the address</param>
	/// <param name="symbolCode7">Code of the 7th symbol of the address</param>
	/// <returns>An object containing the address record or null</returns>
	public Address? FindBySymbols(string symbolCode1, string symbolCode2, string symbolCode3, string symbolCode4, string symbolCode5, string symbolCode6, string symbolCode7)
	{
		return
			_dbSet
			.FirstOrDefault(a =>
				a.Symbol1.Code == symbolCode1
				&& a.Symbol2.Code == symbolCode2
				&& a.Symbol3.Code == symbolCode3
				&& a.Symbol4.Code == symbolCode4
				&& a.Symbol5.Code == symbolCode5
				&& a.Symbol6.Code == symbolCode6
				&& a.Symbol7.Code == symbolCode7
				);
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public AddressRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
