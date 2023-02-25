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
	bool DeleteAddress(uint id);

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
	AddressDto? GetAddress(uint id);


	/// <summary>
	/// Updates a address.
	/// </summary>
	/// <param name="id">Id of the address to be updated</param>
	/// <param name="addressDto">DTO object with modified address</param>
	/// <returns>The updated address or null if the specified address wasn't found</returns>
	AddressDto? UpdateAddress(uint id, AddressDto addressDto);
}