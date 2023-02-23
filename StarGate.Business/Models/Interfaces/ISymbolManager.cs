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
}