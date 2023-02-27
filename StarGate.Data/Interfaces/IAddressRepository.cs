using StarGate.Data.Models;

namespace StarGate.Data.Interfaces;

/// <summary>
/// An interface for a repository of addresses
/// </summary>
public interface IAddressRepository : IBaseRepository<Address>
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
	Address? FindBySymbols(string symbolCode1, string symbolCode2, string symbolCode3, string symbolCode4, string symbolCode5, string symbolCode6, string symbolCode7);
}
