using Microsoft.AspNetCore.Http;

using StarGate.Business.Models;

namespace StarGate.Business.Interfaces;

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
	/// Adds a symbol.
	/// </summary>
	/// <param name="code">A short string identifying the symbol</param>
	/// <param name="name">Name of the symbol</param>
	/// <param name="image">Byte array with image of the symbol</param>
	/// <returns>A DTO object representing the symbol</returns>
	SymbolDto? AddSymbol(string code, string name, IFormFile imageFile);

	/// <summary>
	/// Deletes a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be deleted</param>
	/// <returns>True if the specified symbol was deleted</returns>
	bool DeleteSymbol(int id);

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
	SymbolDto? GetSymbol(int id);

	/// <summary>
	/// Finds a symbol by its code.
	/// </summary>
	/// <param name="code">A code string identifying the symbol</param>
	/// <returns>DTO object of the wanted symbol or null</returns>
	SymbolDto? GetSymbolByCode(string code);

	/// <summary>
	/// Updates a symbol.
	/// </summary>
	/// <param name="id">Id of the symbol to be updated</param>
	/// <param name="symbolDto">DTO object with modified symbol</param>
	/// <returns>The updated symbol or null if the specified symbol wasn't found</returns>
	SymbolDto? UpdateSymbol(int id, SymbolDto symbolDto);


	/// <summary>
	/// Updates a symbol.
	/// </summary>
	/// <param name="code">A short string identifying the symbol to be updated</param>
	/// <param name="symbolDto">DTO object with modified symbol</param>
	/// <returns>The updated symbol or null if the specified symbol wasn't found</returns>
	SymbolDto? UpdateSymbol(string code, SymbolDto symbolDto);
}