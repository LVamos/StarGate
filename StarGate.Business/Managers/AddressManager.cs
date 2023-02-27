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
	public AddressDto? GetAddress(string symbolCode1, string symbolCode2, string symbolCode3, string symbolCode4, string symbolCode5, string symbolCode6, string symbolCode7)
	{
		Address? address = _addressRepository.FindBySymbols(symbolCode1, symbolCode2, symbolCode3, symbolCode4, symbolCode5, symbolCode6, symbolCode7);

		if (address is null)
			return null;

		return _mapper.Map<AddressDto>(address);
	}



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
	public AddressDto? UpdateAddress(int id, AddressDto addressDto)
	{
		if (!_addressRepository.ExistsWithId(id))
			return null;

		Address address = _mapper.Map<Address>(addressDto);
		address.Id = id;
		Address updatedAddress = _addressRepository.Update(address);

		return _mapper.Map<AddressDto>(updatedAddress);
	}

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
	public AddressDto AddAddress(string symbolCode1, string symbolCode2, string symbolCode3, string symbolCode4, string symbolCode5, string symbolCode6, string symbolCode7)
	{
		// Find all symbols.
		int? symbol1Id = _symbolManager.GetSymbolByCode(symbolCode1)?.Id;
		int? symbol2Id = _symbolManager.GetSymbolByCode(symbolCode2)?.Id;
		int? symbol3Id = _symbolManager.GetSymbolByCode(symbolCode3)?.Id;
		int? symbol4Id = _symbolManager.GetSymbolByCode(symbolCode4)?.Id;
		int? symbol5Id = _symbolManager.GetSymbolByCode(symbolCode5)?.Id;
		int? symbol6Id = _symbolManager.GetSymbolByCode(symbolCode6)?.Id;
		int? symbol7Id = _symbolManager.GetSymbolByCode(symbolCode7)?.Id;

		// Check keys.
		if (symbol1Id is null || symbol2Id is null || symbol3Id is null || symbol4Id is null || symbol5Id is null || symbol6Id is null || symbol7Id is null)
			return null;

		// Store the address.
		AddressDto address = new AddressDto
		{
			Symbol1Id = symbol1Id.Value,
			Symbol2Id = symbol2Id.Value,
			Symbol3Id = symbol3Id.Value,
			Symbol4Id = symbol4Id.Value,
			Symbol5Id = symbol5Id.Value,
			Symbol6Id = symbol6Id.Value,
			Symbol7Id = symbol7Id.Value
		};
		return AddAddress(address);
	}

	/// <summary>
	///  Adds a address.
	/// </summary>
	/// <param name="addressDto">The address to be added as an DTO object</param>
	/// <returns>Newly added address as an DTO object</returns>
	public AddressDto AddAddress(AddressDto addressDto)
	{
		Address address = _mapper.Map<Address>(addressDto);

		Address newAddress = _addressRepository.Insert(address);

		return _mapper.Map<AddressDto>(newAddress);
	}

	/// <summary>
	/// Deletes a address.
	/// </summary>
	/// <param name="id">Id of the address to be deleted</param>
	/// <returns>True if the specified address was deleted</returns>
	public bool DeleteAddress(int id)
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
	public AddressDto? GetAddress(int id)
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
	/// The symbol manager
	/// </summary>
	private readonly ISymbolManager _symbolManager;

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
	public AddressManager(IAddressRepository addressRepository, ISymbolManager symbolManager, IMapper mapper)
	{
		_addressRepository = addressRepository;
		_symbolManager = symbolManager;
		_mapper = mapper;
	}
}