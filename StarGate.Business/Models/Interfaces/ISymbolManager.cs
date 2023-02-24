﻿namespace StarGate.Business.Models.Interfaces;

/// <summary>
///  A symbol manager interface.
/// </summary>
public interface ISymbolManager
{
	/// <summary>
	///  Adds a symbol.
	/// </summary>
	/// <param name="symbolDto">The symbol to be added as an DTO object</param>
	/// <returns>Newly added symbol as an DTO object</returns>
	SymbolDto AddSymbol(SymbolDto symbolDto);

	/// <summary>
	/// Deletes a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be deleted</param>
	/// <returns>True if the specified symbol was deleted</returns>
	bool DeleteSymbol(uint id);

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