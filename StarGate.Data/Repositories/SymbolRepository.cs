using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for symbols
/// </summary>
public class SymbolRepository : BaseRepository<Symbol>, ISymbolRepository
{
	/// <summary>
	/// Finds a symbol by its code.
	/// </summary>
	/// <param name="code">A code string identifying the symbol</param>
	/// <returns>DTO object of the wanted symbol or null</returns>
	public Symbol? FindByCode(string code) => _dbContext.Symbols.FirstOrDefault(s => s.Code == code);

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public SymbolRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
