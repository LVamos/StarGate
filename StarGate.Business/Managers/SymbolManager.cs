using AutoMapper;

using StarGate.Business.Models;
using StarGate.Business.Models.Interfaces;
using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Business.Managers;

/// <summary>
///  A symbol manager.
/// </summary>
public class SymbolManager : ISymbolManager
{
	/// <summary>
	/// Updates a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be updated</param>
	/// <param name="symbolDto">DTO object with modified symbol</param>
	/// <returns>The updated symbol or null if the specified symbol wasn't found</returns>
	public SymbolDto? UpdateSymbol(uint id, SymbolDto symbolDto)
	{
		if (!_symbolRepository.ExistsWithId(id))
			return null;

		Symbol symbol = _mapper.Map<Symbol>(symbolDto);
		symbol.Id = id;
		Symbol updatedSymbol = _symbolRepository.Update(symbol);

		return _mapper.Map<SymbolDto>(updatedSymbol);
	}

	/// <summary>
	///  Adds a symbol.
	/// </summary>
	/// <param name="symbolDto">The symbol to be added as an DTO object</param>
	/// <returns>Newly added symbol as an DTO object</returns>
	public SymbolDto AddSymbol(SymbolDto symbolDto)
	{
		Symbol symbol = _mapper.Map<Symbol>(symbolDto);
		symbol.Id = default; // Set to zero so that the primary key can be generated.
		Symbol newSymbol = _symbolRepository.Insert(symbol);

		return _mapper.Map<SymbolDto>(newSymbol);
	}

	/// <summary>
	/// Deletes a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be deleted</param>
	/// <returns>True if the specified symbol was deleted</returns>
	public bool DeleteSymbol(uint id)
	{
		bool found = _symbolRepository.ExistsWithId(id);

		if (found)
			_symbolRepository.Delete(id);

		return found;
	}

	/// <summary>
	///  Gets a symbol.
	/// </summary>
	/// <param name="id">Id of the requested symbol</param>
	/// <returns>A data transformation object</returns>
	public SymbolDto? GetSymbol(uint id)
	{
		Symbol? symbol = _symbolRepository.FindById(id);

		if (symbol is null)
			return null;

		return _mapper.Map<SymbolDto>(symbol);
	}

	/// <summary>
	///  The symbol repository.
	/// </summary>
	private readonly ISymbolRepository _symbolRepository;

	/// <summary>
	/// The mapper
	/// </summary>
	private readonly IMapper _mapper;

	/// <summary>
	///  Returns all symbols.
	/// </summary>
	/// <returns>A list of symbols</returns>
	public IList<SymbolDto> GetAllSymbols()
	{
		IList<Symbol> symbols = _symbolRepository.GetAll();
		return _mapper.Map<IList<SymbolDto>>(symbols);
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="symbolRepository">The symbol repository</param>
	/// <param name="mapper">The mapper</param>
	public SymbolManager(ISymbolRepository symbolRepository, IMapper mapper)
	{
		_symbolRepository = symbolRepository;
		_mapper = mapper;
	}
}