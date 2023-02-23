using StarGate.Data.Interfaces;
using StarGate.Data.Models;

namespace StarGate.Data.Repositories;

/// <summary>
/// A repository for symbols
/// </summary>
public class SymbolRepository : BaseRepository<Symbol>, ISymbolRepository
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="dbContext">Context of a database to work with</param>
	public SymbolRepository(StarGateDbContext dbContext) : base(dbContext)
	{
	}
}
