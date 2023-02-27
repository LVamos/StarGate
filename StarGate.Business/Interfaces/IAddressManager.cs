using StarGate.Business.Models;

namespace StarGate.Business.Interfaces;

/// <summary>
///  A address manager interface.
/// </summary>
public interface IAddressManager
{
	/// <summary>
	///  Adds a address.
	/// </summary>
	/// <param name="addressDto">The address to be added as an DTO object</param>
	/// <returns>Newly added address as an DTO object</returns>
	AddressDto AddAddress(AddressDto addressDto);

	/// <summary>
	/// Deletes a address.
	/// </summary>
	/// <param name="id">Id of the address to be deleted</param>
	/// <returns>True if the specified address was deleted</returns>
	bool DeleteAddress(int id);

	/// <summary>
	///  Returns all addresss.
	/// </summary>
	/// <returns>A list of addresss</returns>
	IList<AddressDto> GetAllAddresses();

	/// <summary>
	///  Gets a address.
	/// </summary>
	/// <param name="id">Id of the requested address</param>
	/// <returns>A data transformation object</returns>
	AddressDto? GetAddress(int id);


	/// <summary>
	/// Updates a address.
	/// </summary>
	/// <param name="id">Id of the address to be updated</param>
	/// <param name="addressDto">DTO object with modified address</param>
	/// <returns>The updated address or null if the specified address wasn't found</returns>
	AddressDto? UpdateAddress(int id, AddressDto addressDto);


	/// <summary>
	/// Adds an address.
	/// </summary>
	/// <param name="symbolCode1">Code of the 1st symbol of the address</param>
	/// <param name="symbolCode2">Code of the 2nd symbol of the address</param>
	/// <param name="symbolCode3">Code of the 3rd symbol of the address</param>
	/// <param name="symbolCode4">Code of the 4th symbol of the address</param>
	/// <param name="symbolCode5">Code of the 5th symbol of the address</param>
	/// <param name="symbolCode6">Code of the 6th symbol fo the address</param>
	/// <param name="symbolCode7">Code of the 7th symbol of the address</param>
	/// <returns>DTO object of the added address or null in case of an exception</returns>
	AddressDto AddAddress(string symbolCode1, string symbolCode2, string symbolCode3, string symbolCode4, string symbolCode5, string symbolCode6, string symbolCode7);

	/// <summary>
	///  Gets a address.
	/// </summary>
	/// <param name="symbolCode1">Code of the 1st symbol of the address</param>
	/// <param name="symbolCode2">Code of the 2nd symbol of the address</param>
	/// <param name="symbolCode3">Code of the 3rd symbol of the address</param>
	/// <param name="symbolCode4">Code of the 4th symbol of the address</param>
	/// <param name="symbolCode5">Code of the 5th symbol of the address</param>
	/// <param name="symbolCode6">Code of the 6th symbol fo the address</param>
	/// <param name="symbolCode7">Code of the 7th symbol of the address</param>
	/// <returns>A data transformation object with the wanted address record or null</returns>
	AddressDto? GetAddress(string symbolCode1, string symbolCode2, string symbolCode3, string symbolCode4, string symbolCode5, string symbolCode6, string symbolCode7);
}