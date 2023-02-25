using AutoMapper;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Business.Managers;

/// <summary>
///  A address manager.
/// </summary>
public class AddressManager : IAddressManager
{
	/// <summary>
	/// Checks if the specified address exists (compared by its symbols).
	/// </summary>
	/// <param name="address">A DTO object with the address to be checked</param>
	/// <returns>True if all symbols match</returns>
	public bool AddressExists(AddressDto address)
	{
		return GetAllAddresses()
			.Any(a =>
			a.Symbol1.Id == address.Symbol1.Id
			&& a.Symbol2.Id == address.Symbol2.Id
			&& a.Symbol3.Id == address.Symbol3.Id
			&& a.Symbol4 == address.Symbol4
			&& a.Symbol5.Id == address.Symbol5.Id
			&& a.Symbol6.Id == address.Symbol6.Id
			&& a.Symbol7.Id == address.Symbol7.Id);
	}

	/// <summary>
	/// Updates a address.
	/// </summary>
	/// <param name="id">Id of the address to be updated</param>
	/// <param name="addressDto">DTO object with modified address</param>
	/// <returns>The updated address or null if the specified address wasn't found</returns>
	public AddressDto? UpdateAddress(uint id, AddressDto addressDto)
	{
		if (!_addressRepository.ExistsWithId(id))
			return null;

		Address address = _mapper.Map<Address>(addressDto);
		address.Id = id;
		Address updatedAddress = _addressRepository.Update(address);

		return _mapper.Map<AddressDto>(updatedAddress);
	}

	/// <summary>
	///  Adds a address.
	/// </summary>
	/// <param name="addressDto">The address to be added as an DTO object</param>
	/// <returns>Newly added address as an DTO object</returns>
	public AddressDto AddAddress(AddressDto addressDto)
	{
		Address address = _mapper.Map<Address>(addressDto);
		address.Id = default; // Set to zero so that the primary key can be generated.
		Address newAddress = _addressRepository.Insert(address);

		return _mapper.Map<AddressDto>(newAddress);
	}

	/// <summary>
	/// Deletes a address.
	/// </summary>
	/// <param name="id">Id of the address to be deleted</param>
	/// <returns>True if the specified address was deleted</returns>
	public bool DeleteAddress(uint id)
	{
		bool found = _addressRepository.ExistsWithId(id);

		if (found)
			_addressRepository.Delete(id);

		return found;
	}

	/// <summary>
	///  Gets a address.
	/// </summary>
	/// <param name="id">Id of the requested address</param>
	/// <returns>A data transformation object</returns>
	public AddressDto? GetAddress(uint id)
	{
		Address? address = _addressRepository.FindById(id);

		if (address is null)
			return null;

		return _mapper.Map<AddressDto>(address);
	}

	/// <summary>
	///  The address repository.
	/// </summary>
	private readonly IAddressRepository _addressRepository;

	/// <summary>
	/// The mapper
	/// </summary>
	private readonly IMapper _mapper;

	/// <summary>
	///  Returns all addresss.
	/// </summary>
	/// <returns>A list of addresss</returns>
	public IList<AddressDto> GetAllAddresses()
	{
		IList<Address> addresss = _addressRepository.GetAll();
		return _mapper.Map<IList<AddressDto>>(addresss);
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="addressRepository">The address repository</param>
	/// <param name="mapper">The mapper</param>
	public AddressManager(IAddressRepository addressRepository, IMapper mapper)
	{
		_addressRepository = addressRepository;
		_mapper = mapper;
	}
}