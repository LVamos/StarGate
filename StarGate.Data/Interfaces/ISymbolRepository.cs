using StarGate.Data.Models;

namespace StarGate.Data.Interfaces;

/// <summary>
/// An interface for a repository of symbols
/// </summary>
public interface ISymbolRepository : IBaseRepository<Symbol>
{
	/// <summary>
	/// Finds a symbol by its code.
	/// </summary>
	/// <param name="code">A code string identifying the symbol</param>
	/// <returns>DTO object of the wanted symbol or null</returns>
	Symbol? FindByCode(string code);
}
