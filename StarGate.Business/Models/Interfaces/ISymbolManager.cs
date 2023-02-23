namespace StarGate.Business.Models.Interfaces;

/// <summary>
///  A symbol manager interface.
/// </summary>
public interface ISymbolManager
{
	/// <summary>
	///  Returns all symbols.
	/// </summary>
	/// <returns>A list of symbols</returns>
	IList<SymbolDto> GetAllSymbols();

	/// <summary>
	///  Gets a symbol.
	/// </summary>
	/// <param name="id">Id of the requested symbol</param>
	/// <returns>A data transformation object</returns>
	SymbolDto? GetSymbol(uint id);
}